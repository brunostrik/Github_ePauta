using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Terminal
{
    public class DAO
    {
        public string CONNECTION_STRING = "Server=192.168.1.220;Database=epauta2016;Uid=admin;Pwd=ifpr23102015;";

        private MySqlConnection connection;
        public DAO()
        {
            CONNECTION_STRING = System.Configuration.ConfigurationSettings.AppSettings["CONNECTION_STRING"];
            connection = new MySqlConnection(CONNECTION_STRING);
        }
        public MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(CONNECTION_STRING);
            }
            try { connection.Close(); } catch (Exception) { }
            try { connection.Open(); } catch (Exception) { }
            return connection;
        }
        public bool TestarBD()
        {
            try
            {
                new MySqlCommand("SELECT 1+1", GetConnection()).ExecuteScalar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string Config(string nome, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT valor FROM config WHERE nome = @Nome";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters["@Nome"].Value = nome;
            MySqlDataReader rs = cmd.ExecuteReader();
            string valor = "";
            if (rs.Read())
            {
                valor = rs.GetString("valor");
            }
            rs.Close();
            return valor;
        }
        public ChamadaDTO Registrar(String cartao, int turno, DateTime dia)
        {
            MySqlConnection con = GetConnection();
            /*  SELECIONA O ALUNO COM O RA FORNECIDO
            *      SE JA EXISTE -> Coleta a foto, o nome e o ID do aluno
            *      SE NÃO EXISTE -> Gera uma exception de cartao não identificado */
            Aluno aluno = CarregarPorCartao(cartao, con);          
            if (aluno == null)
            {
                con.Close();
                throw new Exception("CARTÃO INVÁLIDO");
            }
            //O aluno será colocado na entidade mais a frente

            /*  PROCURA SE JA EXISTE ENTIDADE DE CHAMADA DA DATA E TURNO ATUAL  
            *      SE JA EXISTE -> Coleta o ID
            *      SE NÃO EXISTE -> Gera um erro - hoje não tem aula */
            Chamada chamada = ChamadaAtual(turno, dia, con);
            if (chamada == null)
            {
                con.Close();
                throw new Exception("ERRO AO GERAR CHAMADA");
            }

            /* VERIFICA EM QUAL PROJETO ESTE ALUNO ESTA MATRICULADO NESTE DIA DA SEMANA E NESTE TURNO
             *      SE JA EXISTE -> CARREGA A ENTIDADE
             *      SE NÃO EXISTE -> CAUSA ERRO, SEM AULAS HOJE*/
             //Carregaremos apenas o projeto e o aluno_projeto relacionado
            ChamadaDTO dto = CarregarProjetoMatriculado(aluno.Id, turno, dia, con);
            if (dto == null)
            {
                throw new Exception("VOCÊ NÃO TEM AULAS AGORA");
            }
            //Agora enfim adicionamos o aluno, e o DTO estará completo
            dto.aluno = aluno;

            /*  VERIFICA SE EXISTE UM REGISTRO_CHAMADA DESTE ID_ALUNO_PROJETO E ID_CHAMADA
            *      SE JA EXISTE -> Gera um exception de tentativa de registro duplicado
            *      SE NÃO EXISTE -> Gera a entidade */
            RegistroChamada rc = RegistroAtual(chamada.Id, dto.alunoProjeto.Id, con);
            int idRegistro = 0;
            if (rc == null)
            {
                //INSERT
                idRegistro = RegistraNovaPresenca(chamada.Id, dto.alunoProjeto.Id, con);
            }else
            {
                //UPDATE
                idRegistro = RegistraPresenca(rc.Id, con);
            }
            if (idRegistro == 0)
            {
                con.Close();
                throw new Exception("ERRO AO GERAR REGISTRO DE CHAMADA");
            }
            con.Close();
            return dto;
        }
        public Aluno CarregarPorCartao(string cartao, MySqlConnection con)
        {
            Aluno a = null;
            string CmdString = "SELECT id, nome, id_foto  FROM aluno WHERE cartao = @Card";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Card", MySqlDbType.VarChar);
            cmd.Parameters["@Card"].Value = cartao;
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                a = new Aluno();
                a.Id = rs.GetInt32("id");
                a.Nome = rs.GetString("nome");
                a.Cartao = cartao;               
            }
            rs.Close();
            return a;
        }

 

        public FotoAlunoDTO CarregarFotoAluno(int idAluno, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT f.id as id, f.imagem as imagem FROM foto f JOIN aluno a ON a.id_foto = f.id WHERE a.id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = idAluno;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FotoAlunoDTO foto = null;
            try
            {
                foto = new FotoAlunoDTO();
                foto.IdAluno = idAluno;
                foto.IdFoto = (int)dt.Rows[0]["id"];
                foto.Imagem = (byte[])dt.Rows[0]["imagem"];
                return foto;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Chamada ChamadaAtual(int turno, DateTime dia, MySqlConnection con)
        {
            //Verifica se a chamada ja existe
            string CmdString = "SELECT id, dia, turno, obs, carga_horaria FROM chamada WHERE turno = @Turno AND dia = @Dia";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Turno", MySqlDbType.Int32);
            cmd.Parameters.Add("@Dia", MySqlDbType.Date);
            cmd.Parameters["@Dia"].Value = dia;
            cmd.Parameters["@Turno"].Value = turno;
            MySqlDataReader rs = cmd.ExecuteReader();
            Chamada c = null;
            if (rs.Read())
            {
                c = new Chamada();
                c.Id = rs.GetInt32("id");
                c.Dia = rs.GetDateTime("dia");
                c.Turno = rs.GetInt32("turno");
                c.Obs = rs.GetString("obs");
                c.CargaHoraria = rs.GetInt32("carga_horaria");
            }
            else
            {
                //Não existe
                //Causar erro
                rs.Close();
                throw new Exception("VOCÊ NÃO TEM AULAS AGORA");
                //return CriarEntidadeChamada(dia, turno, con);
            }
            rs.Close();
            return c;
        }
        /*public int CriarEntidadeChamada(DateTime dia, int turno, MySqlConnection con)
        {
            int ch = 0;
            if (turno == 1)
            {
                //MATUTINO
                ch = 255;
            }else
            {
                //VESPETINO
                ch = 90;
            }
            string CmdString = "INSERT INTO chamada (dia, turno, carga_horaria) VALUES (@Dia, @Turno, @CH)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Dia", MySqlDbType.Date);
            cmd.Parameters.Add("@Turno", MySqlDbType.Int32);
            cmd.Parameters.Add("@CH", MySqlDbType.Int32);
            cmd.Parameters["@Dia"].Value = dia;
            cmd.Parameters["@Turno"].Value = turno;
            cmd.Parameters["@CH"].Value = ch;
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                int id = Convert.ToInt32(cmd.LastInsertedId);
                return id;
            }else
            {
                return 0;
            }
        }*/


        public RegistroChamada RegistroAtual(int idChamada, int idAlunoProjeto, MySqlConnection con)
        {
            //Verifica se a chamada ja existe
            string CmdString = "SELECT id, presente  FROM registro_chamada WHERE id_chamada = @Chamada AND id_aluno_projeto = @AlunoProj";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Chamada", MySqlDbType.Int32);
            cmd.Parameters.Add("@AlunoProj", MySqlDbType.Int32);
            cmd.Parameters["@Chamada"].Value = idChamada;
            cmd.Parameters["@AlunoProj"].Value = idAlunoProjeto;
            MySqlDataReader rs = cmd.ExecuteReader();
            RegistroChamada rc = null;
            if (rs.Read()) //se existe vai criar a entidade, se nao existe vai retornar null
            {
                rc = new RegistroChamada();
                rc.Id = rs.GetInt32("id");
                rc.Presente = rs.GetInt32("presente");
                rc.IdAlunoProjeto = idAlunoProjeto;
                rc.IdChamada = idChamada;
            }
            rs.Close();
            return rc;
        }
        public int RegistraNovaPresenca(int idChamada, int idAlunoProjeto, MySqlConnection con)
        {
            string CmdString = "INSERT INTO registro_chamada (id_aluno_projeto, id_chamada, presente)"+
                                " VALUES (@AlunoProj, @Chamada, @Presente)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@AlunoProj", MySqlDbType.Int32);
            cmd.Parameters.Add("@Chamada", MySqlDbType.Int32);
            cmd.Parameters.Add("@Presente", MySqlDbType.Int32);
            cmd.Parameters["@AlunoProj"].Value = idAlunoProjeto;
            cmd.Parameters["@Chamada"].Value = idChamada;
            cmd.Parameters["@Presente"].Value = 1;
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                int id = Convert.ToInt32(cmd.LastInsertedId);
                return id;
            }
            else
            {
                return 0;
            }
        }
        public int RegistraPresenca(int idRegistroChamadaExistente, MySqlConnection con)
        {
            string CmdString = "UPDATE registro_chamada SET presente = 1 WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = idRegistroChamadaExistente;
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return idRegistroChamadaExistente;
            }
            else
            {
                return 0;
            }
        }
        public ChamadaDTO CarregarProjetoMatriculado(int idAluno, int turno, DateTime dia, MySqlConnection con)
        {
            string CmdString = "SELECT " +
                                "p.id as idprojeto, " +
                                "p.nome as nomeprojeto, " +
                                "p.dia_da_semana as diaprojeto, " +
                                "p.id_professor as profprojeto, " +
                                "ap.id as idalunoprojeto " +
                                "FROM " +
                                "projeto p " +
                                "JOIN aluno_projeto ap ON ap.id_projeto = p.id " +
                                "WHERE " +
                                "ap.id_aluno = @IdAluno AND " +
                                "p.turno = @Turno";
            if (turno != 1)//TURNO VESPERTINO DEVE VISAR O DIA DA SEMANA
            { 
                CmdString += " AND p.dia_da_semana = WEEKDAY(@Dia)"; //MYSQL considera SEGUNDA=0, TERÇA=1...
            }
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdAluno", MySqlDbType.Int32);
            cmd.Parameters.Add("@Turno", MySqlDbType.Int32);           
            cmd.Parameters["@IdAluno"].Value = idAluno;
            cmd.Parameters["@Turno"].Value = turno;
            if (turno != 1) //TURNO VESPERTINO DEVE VISAR O DIA DA SEMANA
            { 
                cmd.Parameters.Add("@Dia", MySqlDbType.Date);
                cmd.Parameters["@Dia"].Value = dia;
            }
            MySqlDataReader rs = cmd.ExecuteReader();
            ChamadaDTO chamada = null;
            if (rs.Read())
            {
                chamada = new ChamadaDTO();
                AlunoProjeto ap = new AlunoProjeto();
                ap.Id = rs.GetInt32("idalunoprojeto");
                ap.IdProjeto = rs.GetInt32("idprojeto");
                ap.IdAluno = idAluno;
                Projeto p = new Projeto();
                p.Id = rs.GetInt32("idprojeto");
                p.Nome = rs.GetString("nomeprojeto");
                p.DiaDaSemana = rs.GetInt32("diaprojeto");
                p.IdProfessor = rs.GetInt32("profprojeto");
                p.Turno = turno;
                chamada.projeto = p;
                chamada.alunoProjeto = ap;
            }
            rs.Close();
            return chamada;
        }
        public List<Projeto> TodosProjetos(MySqlConnection con = null)
        {
            List<Projeto> list = new List<Projeto>();
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT * FROM projeto ORDER BY nome ASC";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Projeto p = new Projeto();
                p.Id = rs.GetInt32("id");
                p.Nome = rs.GetString("nome");
                p.DiaDaSemana = rs.GetInt32("dia_da_semana");
                p.Turno = rs.GetInt32("turno");
                p.IdProfessor = rs.GetInt32("id_professor");
                list.Add(p);
            }
            rs.Close();
            return list;
        }
        public List<ProjetoDTO> TodosProjetosDTO(MySqlConnection con = null)
        {
            List<ProjetoDTO> list = new List<ProjetoDTO>();
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT id, nome, dia_da_semana, turno FROM projeto ORDER BY nome ASC";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                ProjetoDTO p = new ProjetoDTO();
                p.Id = rs.GetInt32("id");
                p.Nome = rs.GetString("nome");
                p.DiaDaSemana = rs.GetString("dia_da_semana");
                p.Turno = rs.GetString("turno");
                list.Add(p);
            }
            rs.Close();
            return list;
        }
        public List<Aluno> TodosAlunos(MySqlConnection con = null)
        {
            List<Aluno> list = new List<Aluno>();
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT * FROM aluno ORDER BY nome ASC";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Aluno a = new Aluno();
                a.Id = rs.GetInt32("id");
                a.Nome = rs.GetString("nome");
                a.Cartao = rs.GetString("cartao");               
                list.Add(a);
            }
            rs.Close();
            return list;
        }
        public DataTable RelatorioPivot(Projeto p, DateTime inicio, DateTime fim, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            DataTable dt = new DataTable();
            //CARREGAR AS COLUNAS
            //Caso projeto seja matutino o dia da semana é -1:
            string filtroDDS = "";
            if (p.DiaDaSemana >= 0)
            {
                filtroDDS = "AND WEEKDAY(c.dia) = @DiaDaSemana"; //Adiciona aqui o criterio na query quando é projeto optativo
            }
                string CmdString = "SELECT c.dia as dia FROM chamada c WHERE c.turno = @Turno"+
                                " AND c.dia >= @DiaInicio AND c.dia <= @DiaFim "+ filtroDDS+
                                " ORDER BY 1 ASC";
            
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@DiaDaSemana", MySqlDbType.Int32);
            cmd.Parameters.Add("@Turno", MySqlDbType.Int32);
            cmd.Parameters.Add("@DiaInicio", MySqlDbType.Date);
            cmd.Parameters.Add("@DiaFim", MySqlDbType.Date);
            cmd.Parameters["@DiaDaSemana"].Value = p.DiaDaSemana;
            cmd.Parameters["@Turno"].Value = p.Turno;
            cmd.Parameters["@DiaInicio"].Value = inicio;
            cmd.Parameters["@DiaFim"].Value = fim;
            List<DateTime> dias = new List<DateTime>(); //Lista de dias de aula no projeto
            MySqlDataReader rs = cmd.ExecuteReader();           
            while (rs.Read())
            {
                dias.Add(rs.GetDateTime("dia"));
            }
            rs.Close();

            //CARREGAR TODOS OS ALUNOS MATRICULADOS NO PROJETO
            CmdString = "SELECT a.id, a.nome FROM aluno a JOIN aluno_projeto ap ON ap.id_aluno = a.id WHERE ap.id_projeto = @IdProjeto GROUP BY 1";
            cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdProjeto", MySqlDbType.Int32);
            cmd.Parameters["@IdProjeto"].Value = p.Id;
            List<Aluno> alunos = new List<Aluno>();
            rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Aluno a = new Aluno();
                a.Id = rs.GetInt32("id");
                a.Nome = rs.GetString("nome");
                alunos.Add(a);
            }
            rs.Close();

            //UNIFICAR TABELA
            dt.Columns.Add("ESTUDANTE"); //Coluna para o nome do estudante
            foreach (DateTime dia in dias)
            {
                dt.Columns.Add(dia.ToShortDateString()); //Colunas com os dias
            }
            dt.Columns.Add("TOTAL (Horas)"); //Coluna com o valor total

            //GERAR CÉLULAS
            foreach (Aluno a in alunos)
            {
                double total = 0; //Cria variavel que contabilizará o total
                DataRow r = dt.NewRow();
                r["ESTUDANTE"] = a.Nome;
                foreach (DateTime dia in dias) //Percorre todas as datas de aula
                {
                    CmdString = "SELECT (rc.presente * c.carga_horaria)/60 as CH FROM registro_chamada rc "+
                                "JOIN chamada c ON c.id = rc.id_chamada JOIN aluno_projeto ap ON ap.id = rc.id_aluno_projeto "+
                                "WHERE ap.id_aluno = @IdAluno AND c.dia = @Dia AND c.turno = @Turno";
                    cmd = new MySqlCommand(CmdString, con);
                    cmd.Parameters.Add("@IdAluno", MySqlDbType.Int32);
                    cmd.Parameters["@IdAluno"].Value = a.Id;
                    cmd.Parameters.Add("@Dia", MySqlDbType.Date);
                    cmd.Parameters["@Dia"].Value = dia;
                    cmd.Parameters.Add("@Turno", MySqlDbType.Int32);
                    cmd.Parameters["@Turno"].Value = p.Turno;
                    rs = cmd.ExecuteReader();
                    double ch = 0;
                    if (rs.Read())
                    {
                        ch = rs.GetDouble("CH");
                    }
                    rs.Close();
                    r[dia.ToShortDateString()] = Math.Round(ch,2);
                    total += ch;
                }
                r["TOTAL (Horas)"] = Math.Round(total,2);
                dt.Rows.Add(r);
            }
            dt.Columns["TOTAL (Horas)"].SetOrdinal(1);
            return dt;
        }
        public DataTable RelatorioAluno(Aluno a, DateTime inicio, DateTime fim, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT c.dia as DIA, "+
                                "IFNULL(( "+
                                "    SELECT rech.presente * cha.carga_horaria "+
                                "    FROM registro_chamada rech "+
                                "    JOIN chamada cha ON cha.id = rech.id_chamada "+
                                "    WHERE rech.id_aluno_projeto = ap.id AND cha.dia = c.dia AND cha.turno = 1 "+
                                "),0)/60 as MATUTINO, "+
                                "IFNULL(("+
                                "    SELECT rech.presente * cha.carga_horaria "+
                                "    FROM registro_chamada rech "+
                                "    JOIN chamada cha ON cha.id = rech.id_chamada "+
                                "    WHERE rech.id_aluno_projeto = ap.id AND cha.dia = c.dia AND cha.turno = 2 "+
                                "),0)/60 as 'VESPERTINO A', " +
                                "IFNULL(("+
                                "    SELECT rech.presente * cha.carga_horaria "+
                                "    FROM registro_chamada rech "+
                                "    JOIN chamada cha ON cha.id = rech.id_chamada "+
                                "    WHERE rech.id_aluno_projeto = ap.id AND cha.dia = c.dia AND cha.turno = 3 "+
                                "),0)/60 as 'VESPERTINO B', " +
                                "(IFNULL(("+
                                "    SELECT rech.presente * cha.carga_horaria "+
                                "    FROM registro_chamada rech "+
                                "    JOIN chamada cha ON cha.id = rech.id_chamada "+
                                "    WHERE rech.id_aluno_projeto = ap.id AND cha.dia = c.dia AND cha.turno = 1 "+
                                "),0)/60+IFNULL((" +
                                "    SELECT rech.presente * cha.carga_horaria "+
                                "    FROM registro_chamada rech "+
                                "    JOIN chamada cha ON cha.id = rech.id_chamada "+
                                "    WHERE rech.id_aluno_projeto = ap.id AND cha.dia = c.dia AND cha.turno = 2 "+
                                "),0)/60+IFNULL((" +
                                "    SELECT rech.presente * cha.carga_horaria "+
                                "    FROM registro_chamada rech "+
                                "    JOIN chamada cha ON cha.id = rech.id_chamada "+
                                "    WHERE rech.id_aluno_projeto = ap.id AND cha.dia = c.dia AND cha.turno = 3 "+
                                "),0)/60) as TOTAL " +
                                "FROM "+
                                "    registro_chamada rc "+
                                "    JOIN chamada c on rc.id_chamada = c.id "+
                                "    JOIN aluno_projeto ap ON rc.id_aluno_projeto = ap.id "+
                                "WHERE "+
                                "    ap.id_aluno = @IdAluno "+
                                "    AND c.dia >= @DiaInicio "+
                                "    AND c.dia <= @DiaFim "+
                                "GROUP BY "+
                                "    c.dia";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdAluno", MySqlDbType.Int32);
            cmd.Parameters["@IdAluno"].Value = a.Id;
            cmd.Parameters.Add("@DiaInicio", MySqlDbType.Date);
            cmd.Parameters["@DiaInicio"].Value = inicio;
            cmd.Parameters.Add("@DiaFim", MySqlDbType.Date);
            cmd.Parameters["@DiaFim"].Value = fim;
            MySqlDataReader rs = cmd.ExecuteReader();
            //TRANSFORMA EM DATATABLE
            DataTable dt = new DataTable();
            dt.Columns.Add("DIA");
            dt.Columns.Add("MATUTINO");
            dt.Columns.Add("VESPERTINO A");
            dt.Columns.Add("VESPERTINO B");
            dt.Columns.Add("TOTAL (horas)");
            double tMatutino = 0;
            double tVespertinoA = 0;
            double tVespertinoB = 0;
            while (rs.Read())
            {
                DataRow novaLinha = dt.NewRow();
                novaLinha["DIA"] = rs.GetDateTime("DIA").ToShortDateString();
                novaLinha["MATUTINO"] = rs.GetDouble("MATUTINO");
                tMatutino += rs.GetDouble("MATUTINO");
                novaLinha["VESPERTINO A"] = rs.GetDouble("VESPERTINO A");
                tVespertinoA += rs.GetDouble("VESPERTINO A");
                novaLinha["VESPERTINO B"] = rs.GetDouble("VESPERTINO B");
                tVespertinoB += rs.GetDouble("VESPERTINO B");
                novaLinha["TOTAL (horas)"] = rs.GetDouble("TOTAL");
                dt.Rows.Add(novaLinha);
            }
            DataRow r = dt.NewRow();
            r["DIA"] = "TOTAL GERAL";
            r["MATUTINO"] = tMatutino;
            r["VESPERTINO A"] = tVespertinoA;
            r["VESPERTINO B"] = tVespertinoB;
            r["TOTAL (horas)"] = tMatutino + tVespertinoA + tVespertinoB;
            dt.Rows.Add(r);
            return dt;

        }
        public DataTable ObterTabela(MySqlDataReader reader)
        {
            DataTable tbEsquema = reader.GetSchemaTable();
            DataTable tbRetorno = new DataTable();
            foreach (DataRow r in tbEsquema.Rows)
            {
                if (!tbRetorno.Columns.Contains(r["ColumnName"].ToString()))
                {
                    DataColumn col = new DataColumn()
                    {
                        ColumnName = r["ColumnName"].ToString(),
                        Unique = Convert.ToBoolean(r["IsUnique"]),
                        AllowDBNull = Convert.ToBoolean(r["AllowDBNull"]),
                        ReadOnly = Convert.ToBoolean(r["IsReadOnly"])
                    };
                    tbRetorno.Columns.Add(col);
                }
            }
            while (reader.Read())
            {
                DataRow novaLinha = tbRetorno.NewRow();
                for (int i = 0; i < tbRetorno.Columns.Count; i++)
                {
                    novaLinha[i] = reader.GetValue(i);
                }
                tbRetorno.Rows.Add(novaLinha);
            }
            return tbRetorno;
        }
        public int ExcluirProjeto(int idProjeto, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            //CONSTRAINTS DEFINIDAS MANUALMENTE
            if (ContarAlunoProjeto(idProjeto, 0) > 0) throw new Exception("Este projeto ainda possui estudantes matriculados e por isso não pode ser excluído.");
            string CmdString = "DELETE FROM projeto WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);          
            cmd.Parameters["@ID"].Value = idProjeto;
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public int ProjetoInsert(Projeto p, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "INSERT INTO projeto (nome, dia_da_semana, turno) VALUES (@Nome, @DDS, @Turno)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@DDS", MySqlDbType.Int32);
            cmd.Parameters.Add("@Turno", MySqlDbType.Int32);
            cmd.Parameters["@Nome"].Value = p.Nome;
            cmd.Parameters["@DDS"].Value = p.DiaDaSemana;
            cmd.Parameters["@Turno"].Value = p.Turno;
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public int ProjetoUpdate(Projeto p, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "UPDATE projeto SET nome = @Nome, dia_da_semana = @DDS, turno = @Turno WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@DDS", MySqlDbType.Int32);
            cmd.Parameters.Add("@Turno", MySqlDbType.Int32);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@Nome"].Value = p.Nome;
            cmd.Parameters["@DDS"].Value = p.DiaDaSemana;
            cmd.Parameters["@Turno"].Value = p.Turno;
            cmd.Parameters["@ID"].Value = p.Id;
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public Projeto CarregarProjeto(int id, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT id, nome, dia_da_semana, turno FROM projeto WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = id;
            MySqlDataReader rs = cmd.ExecuteReader();
            Projeto p = null;
            if (rs.Read())
            {
                p = new Projeto();
                p.Id = rs.GetInt32("id");
                p.Nome = rs.GetString("nome");
                p.DiaDaSemana = rs.GetInt32("dia_da_semana");
                p.Turno = rs.GetInt32("turno");
            }
            rs.Close();
            return p;
        }
        public int ContarAlunoProjeto(int idProjeto, int idAluno, MySqlConnection con = null)
        {
            string CmdString = "SELECT COUNT(id) as total FROM aluno_projeto ";
            if (con == null)
            {
                con = GetConnection();
            }
            if (idProjeto > 0) //CONTAGEM POR PROJETO
            {
                CmdString += "WHERE id_projeto = '"+idProjeto+"'"; 

            }else if (idAluno > 0) //CONTAGEM POR ALUNO
            {
                CmdString += "WHERE id_aluno = '"+idAluno+"'";
            }
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            MySqlDataReader rs = cmd.ExecuteReader();
            int contagem = 0;
            if (rs.Read())
            {
                contagem = rs.GetInt32("total");
            }
            rs.Close();
            return contagem;

        }
        public Aluno CarregarAluno(int id, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT id, nome, cartao FROM aluno WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = id;
            MySqlDataReader rs = cmd.ExecuteReader();
            Aluno a = null;
            if (rs.Read())
            {
                a = new Aluno();
                a.Id = rs.GetInt32("id");
                a.Nome = rs.GetString("nome");
                a.Cartao = rs.GetString("cartao");
            }
            rs.Close();
            return a;
        }
        public int ExcluirAluno(int idAluno, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            //CONSTRAINTS DEFINIDAS MANUALMENTE
            if (ContarAlunoProjeto(0,idAluno) > 0) throw new Exception("Este estudante ainda está matriculado em projetos e por isso não pode ser excluído.");
            string CmdString = "DELETE FROM aluno WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = idAluno;
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public int AlunoInsert(Aluno a, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "INSERT INTO aluno (nome, cartao) VALUES (@Nome, @Cartao)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Cartao", MySqlDbType.VarChar);
            cmd.Parameters["@Nome"].Value = a.Nome;
            cmd.Parameters["@Cartao"].Value = a.Cartao;
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                int id = Convert.ToInt32(cmd.LastInsertedId);
                return id;
            }
            else
            {
                return 0;
            }
        }
        public int AlunoUpdate(Aluno a, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "UPDATE aluno SET nome = @Nome, cartao = @Cartao WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Cartao", MySqlDbType.VarChar);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@Nome"].Value = a.Nome;
            cmd.Parameters["@Cartao"].Value = a.Cartao;
            cmd.Parameters["@ID"].Value = a.Id;
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public List<ProjetoDTO> CarregarProjetosDiaTurno(int diaDaSemana, int turno, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            List<ProjetoDTO> list = new List<ProjetoDTO>();
            ProjetoDTO nenhum = new ProjetoDTO();
            nenhum.Id = 0; //Adiciona o projeto nenhum para a pessoa ter essa opção na hora de escolher
            nenhum.Nome = "Nenhum";
            list.Add(nenhum);
            string CmdString = "SELECT id, nome FROM projeto WHERE dia_da_semana = @DDS AND turno = @TRN";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@DDS", MySqlDbType.Int32);
            cmd.Parameters.Add("@TRN", MySqlDbType.Int32);
            cmd.Parameters["@DDS"].Value = diaDaSemana;
            cmd.Parameters["@TRN"].Value = turno;
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                ProjetoDTO p = new ProjetoDTO();
                p.Id = rs.GetInt32("id");
                p.Nome = rs.GetString("nome");
                p.Turno = Program.Turno(turno);
                p.DiaDaSemana = Program.DiaDaSemana(diaDaSemana);
                list.Add(p);
            }
            rs.Close();
            return list;

        }
        public MatriculaDTO CarregarMatriculas(int idAluno, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            MatriculaDTO mat = new MatriculaDTO();
            //CARREGA O ALUNO
            mat.aluno = CarregarAluno(idAluno);          
            //CARREGAR OS PROJETOS            
            string CmdString = "SELECT ap.id as id_aluno_projeto, ap.id_aluno as id_aluno, ap.id_projeto AS id_projeto, p.dia_da_semana as dia_da_semana, p.turno as turno "+
                                "FROM aluno_projeto ap JOIN projeto p ON ap.id_projeto = p.id WHERE ap.id_aluno = @IdAluno";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdAluno", MySqlDbType.Int32);
            cmd.Parameters["@IdAluno"].Value = idAluno;
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                AlunoProjeto ap = new AlunoProjeto();
                ap.Id = rs.GetInt32("id_aluno_projeto");
                ap.IdAluno = idAluno;
                ap.IdProjeto = rs.GetInt32("id_projeto");
                int diaDaSemana = rs.GetInt32("dia_da_semana");
                int turno = rs.GetInt32("turno");
                if (turno == 1) //PROJETO MATUTINO
                {
                    mat.projetoMatutino = ap;
                }
                else//PROJETOS VESPERTINOS
                { 
                    switch (diaDaSemana)
                    {
                        case 0:
                            if (turno == 2)
                            {
                                mat.projetoD0T2 = ap;
                            }
                            else
                            {
                                mat.projetoD0T3 = ap;
                            }
                            break;
                        case 1: //TERÇA
                            if (turno == 2)
                            {
                                mat.projetoD1T2 = ap;
                            }
                            else
                            {
                                mat.projetoD1T3 = ap;
                            }
                            break;
                        case 2: //QUARTA
                            if (turno == 2)
                            {
                                mat.projetoD2T2 = ap;
                            }
                            else
                            {
                                mat.projetoD2T3 = ap;
                            }
                            break;
                        case 3: //QUINTA
                            if (turno == 2)
                            {
                                mat.projetoD3T2 = ap;
                            }
                            else
                            {
                                mat.projetoD3T3 = ap;
                            }
                            break;
                        case 4: //SEXTA
                            if (turno == 2)
                            {
                                mat.projetoD4T2 = ap;
                            }
                            else
                            {
                                mat.projetoD4T3 = ap;
                            }
                            break;
                    }
                }
            }
            rs.Close();
            return mat;
        }

        public void SalvarMatriculas(MatriculaDTO matriculas, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            MySqlTransaction trans = con.BeginTransaction();
            try
            {
                ProcessarMatricula(matriculas.projetoMatutino, con, trans); //MATUTINO
                ProcessarMatricula(matriculas.projetoD0T2, con, trans); //SEGUNDA A
                ProcessarMatricula(matriculas.projetoD0T3, con, trans); //SEGUNDA B
                ProcessarMatricula(matriculas.projetoD1T2, con, trans); //TERÇA A
                ProcessarMatricula(matriculas.projetoD1T3, con, trans); //TERÇA B
                ProcessarMatricula(matriculas.projetoD2T2, con, trans); //QUARTA A
                ProcessarMatricula(matriculas.projetoD2T3, con, trans); //QUARTA B
                ProcessarMatricula(matriculas.projetoD3T2, con, trans); //QUINTA A
                ProcessarMatricula(matriculas.projetoD3T3, con, trans); //QUINTA B
                ProcessarMatricula(matriculas.projetoD4T2, con, trans); //SEXTA A
                ProcessarMatricula(matriculas.projetoD4T3, con, trans); //SEXTA B
                trans.Commit();
            }
            catch(Exception ex)
            {
                trans.Rollback();
                throw ex;
            }

        }
        public void ProcessarMatricula(AlunoProjeto ap, MySqlConnection con = null, MySqlTransaction trans = null)
        {
            if (ap.Id == 0) //É UM NOVO ELEMENTO
            {
                if (ap.IdProjeto != 0) //INSERT
                {
                    InserirMatricula(ap, con, trans);
                }
            }
            else //É UM ELEMENTO JÁ EXISTENTE
            {
                if (ap.IdProjeto != 0) //UPDATE
                {
                    AtualizarMatricula(ap, con, trans);
                }
                else //DELETE
                {
                    ExcluirMatricula(ap.Id, con, trans);
                }
            }
        }
        public void ExcluirMatricula(int idAlunoProjeto, MySqlConnection con = null, MySqlTransaction trans = null)
        {
            string CmdString = "DELETE FROM aluno_projeto WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con, trans);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = idAlunoProjeto;
            cmd.ExecuteNonQuery();
        }
        public void AtualizarMatricula(AlunoProjeto ap, MySqlConnection con = null, MySqlTransaction trans = null)
        {
            string CmdString = "UPDATE aluno_projeto SET id_projeto = @IdProjeto WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con, trans);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = ap.Id;
            cmd.Parameters.Add("@IdProjeto", MySqlDbType.Int32);
            cmd.Parameters["@IdProjeto"].Value = ap.IdProjeto;
            cmd.ExecuteNonQuery();
        }
        public void InserirMatricula(AlunoProjeto ap, MySqlConnection con = null, MySqlTransaction trans = null)
        {
            string CmdString = "INSERT INTO aluno_projeto (id_projeto, id_aluno) VALUES (@IdProjeto, @IdAluno)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con, trans);
            cmd.Parameters.Add("@IdProjeto", MySqlDbType.Int32);
            cmd.Parameters["@IdProjeto"].Value = ap.IdProjeto;
            cmd.Parameters.Add("@IdAluno", MySqlDbType.Int32);
            cmd.Parameters["@IdAluno"].Value = ap.IdAluno;
            cmd.ExecuteNonQuery();
        }
        public List<CalendarioDTO> CarregarChamadasCalendario(int mes, MySqlConnection con = null)
        {
            List<CalendarioDTO> list = new List<CalendarioDTO>();
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT c.dia AS Dia, WEEKDAY(c.dia) AS 'Dia da Semana', " +
                "IFNULL((SELECT cha.carga_horaria FROM chamada cha WHERE cha.dia = c.dia AND cha.turno = 1),0)/60 AS Matutino, " +
                "IFNULL((SELECT cha.carga_horaria FROM chamada cha WHERE cha.dia = c.dia AND cha.turno = 2),0)/60 AS 'Vespertino A', " +
                "IFNULL((SELECT cha.carga_horaria FROM chamada cha WHERE cha.dia = c.dia AND cha.turno = 3),0)/ 60 AS 'Vespertino B', " +
                "IFNULL((SELECT cha.id FROM chamada cha WHERE cha.dia = c.dia AND cha.turno = 1),0) as 'ID Matutino', "+
                "IFNULL((SELECT cha.id FROM chamada cha WHERE cha.dia = c.dia AND cha.turno = 2),0) as 'ID Vespertino A'," +
                "IFNULL((SELECT cha.id FROM chamada cha WHERE cha.dia = c.dia AND cha.turno = 3),0) as 'ID Vespertino B'" +
                "FROM chamada c WHERE MONTH(dia) = @Mes GROUP BY c.dia ORDER BY c.dia ASC";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Mes", MySqlDbType.Int32);
            cmd.Parameters["@Mes"].Value = mes;
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                CalendarioDTO c = new CalendarioDTO();
                c.Dia = rs.GetDateTime("Dia");
                c.DiaDaSemana = rs.GetInt32("Dia da Semana");
                c.Matutino = rs.GetDouble("Matutino");
                c.VespertinoA = rs.GetDouble("Vespertino A");
                c.VespertinoB = rs.GetDouble("Vespertino B");
                c.idMatutino = rs.GetInt32("ID Matutino");
                c.idVespertinoA = rs.GetInt32("ID Vespertino A");
                c.idVespertinoB = rs.GetInt32("ID Vespertino B");
                list.Add(c);
            }
            rs.Close();
            return list;
        }
        public void ExcluirChamada(int idChamada, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "DELETE FROM chamada WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = idChamada;
            cmd.ExecuteNonQuery();
        }
        public void ExcluirChamadaDia(DateTime dia, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "DELETE FROM chamada WHERE dia = @DIA";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@DIA", MySqlDbType.DateTime);
            cmd.Parameters["@DIA"].Value = dia;
            cmd.ExecuteNonQuery();
        }
        public void AtualizarChamada(Chamada c, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "UPDATE chamada SET dia = @DIA, turno = @TURNO, obs = @OBS, carga_horaria = @CH WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = c.Id;
            cmd.Parameters.Add("@DIA", MySqlDbType.Date);
            cmd.Parameters["@DIA"].Value = c.Dia;
            cmd.Parameters.Add("@TURNO", MySqlDbType.Int32);
            cmd.Parameters["@TURNO"].Value = c.Turno;
            cmd.Parameters.Add("@OBS", MySqlDbType.VarChar);
            cmd.Parameters["@OBS"].Value = c.Obs;
            cmd.Parameters.Add("@CH", MySqlDbType.Int32);
            cmd.Parameters["@CH"].Value = c.CargaHoraria;
            cmd.ExecuteNonQuery();
        }
        public void InserirChamada(Chamada c, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "INSERT INTO chamada (dia, turno, obs, carga_horaria) VALUES (@DIA, @TURNO, @OBS, @CH)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@DIA", MySqlDbType.Date);
            cmd.Parameters["@DIA"].Value = c.Dia;
            cmd.Parameters.Add("@TURNO", MySqlDbType.Int32);
            cmd.Parameters["@TURNO"].Value = c.Turno;
            cmd.Parameters.Add("@OBS", MySqlDbType.VarChar);
            cmd.Parameters["@OBS"].Value = c.Obs;
            cmd.Parameters.Add("@CH", MySqlDbType.Int32);
            cmd.Parameters["@CH"].Value = c.CargaHoraria;
            cmd.ExecuteNonQuery();
        }
        public void InserirChamadaMulti(List<Chamada> list, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            MySqlTransaction trans = con.BeginTransaction();
            MySqlCommand cmd;
            MySqlDataReader rs;
            string CmdString;
            try
            {
                foreach (Chamada c in list)
                {
                    //verifica se já não existe chamada nesse dia
                    CmdString = "SELECT id FROM chamada WHERE dia = @DIA AND turno = @TURNO";
                    cmd = new MySqlCommand(CmdString, con, trans);
                    cmd.Parameters.Add("@DIA", MySqlDbType.Date);
                    cmd.Parameters["@DIA"].Value = c.Dia;
                    cmd.Parameters.Add("@TURNO", MySqlDbType.Int32);
                    cmd.Parameters["@TURNO"].Value = c.Turno;
                    rs = cmd.ExecuteReader();
                    bool jaExiste = false;
                    if (rs.Read())
                    {
                        jaExiste = true;
                    }
                    rs.Close();
                    if (jaExiste)
                    {
                        continue; //ignorar esse
                    }
                    else
                    {
                        CmdString = "INSERT INTO chamada (dia, turno, obs, carga_horaria) VALUES (@DIA, @TURNO, @OBS, @CH)";
                        cmd = new MySqlCommand(CmdString, con, trans);
                        cmd.Parameters.Add("@DIA", MySqlDbType.Date);
                        cmd.Parameters["@DIA"].Value = c.Dia;
                        cmd.Parameters.Add("@TURNO", MySqlDbType.Int32);
                        cmd.Parameters["@TURNO"].Value = c.Turno;
                        cmd.Parameters.Add("@OBS", MySqlDbType.VarChar);
                        cmd.Parameters["@OBS"].Value = c.Obs;
                        cmd.Parameters.Add("@CH", MySqlDbType.Int32);
                        cmd.Parameters["@CH"].Value = c.CargaHoraria;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }

        }
        public Chamada CarregarChamada(int idChamada, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT * FROM chamada WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = idChamada;
            MySqlDataReader rs = cmd.ExecuteReader();
            Chamada c = new Chamada();
            while (rs.Read())
            {
                c.Id = rs.GetInt32("id");
                c.Dia = rs.GetDateTime("dia");
                c.Turno = rs.GetInt32("turno");
                c.Obs = rs.GetString("obs");
                c.CargaHoraria = rs.GetInt32("carga_horaria");
            }
            rs.Close();
            return c;
        }
        public bool ChamadaEmConflito(Chamada chamadaNova, MySqlConnection con = null)
        {
            if (chamadaNova.Id == 0) return false;
            if (con == null)
            {
                con = GetConnection();
            }
            string CmdString = "SELECT id FROM chamada WHERE dia = @DIA AND turno = @TURNO AND id <> @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = chamadaNova.Id;
            cmd.Parameters.Add("@DIA", MySqlDbType.Date);
            cmd.Parameters["@DIA"].Value = chamadaNova.Dia;
            cmd.Parameters.Add("@TURNO", MySqlDbType.Int32);
            cmd.Parameters["@TURNO"].Value = chamadaNova.Turno;
            MySqlDataReader rs = cmd.ExecuteReader();
            bool res = false;
            if (rs.Read())
            {
                res = true;
            }
            rs.Close();
            return res;
        }
        public void PersistirFotoAluno(FotoAlunoDTO foto, MySqlConnection con = null)
        {
            if (con == null)
            {
                con = GetConnection();
            }
            MySqlTransaction trans = con.BeginTransaction();
            try
            {
                string CmdString = "";
                if (foto.IdFoto == 0) //INSERT
                {
                    CmdString = "INSERT INTO foto (id, imagem) VALUES (@Id, @Imagem)";
                }
                else //UPDATE
                {
                    CmdString = "UPDATE foto SET imagem = @Imagem WHERE id = @Id";
                }
                MySqlCommand cmd = new MySqlCommand(CmdString, con, trans);
                cmd.Parameters.Add("@Id", MySqlDbType.Int32);
                cmd.Parameters["@Id"].Value = foto.IdFoto;
                cmd.Parameters.Add("@Imagem", MySqlDbType.MediumBlob);
                cmd.Parameters["@Imagem"].Value = foto.Imagem;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //SÓ SERÁ NECESSÁRIO ATUALIZAR O ALUNO EM CASO DE INSERT DE FOTO NOVA
                    if (foto.IdFoto == 0)
                    {
                        int id = Convert.ToInt32(cmd.LastInsertedId);
                        //Atualizar o aluno com o id da foto aqui
                        CmdString = "UPDATE aluno SET id_foto = @IdFoto WHERE id = @IdAluno";
                        cmd = new MySqlCommand(CmdString, con, trans);
                        cmd.Parameters.Add("@IdAluno", MySqlDbType.Int32);
                        cmd.Parameters["@IdAluno"].Value = foto.IdAluno;
                        cmd.Parameters.Add("@IdFoto", MySqlDbType.Int32);
                        cmd.Parameters["@IdFoto"].Value = id;
                        rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            trans.Rollback();
                            return;
                        }
                    }
                }
                else
                {
                    trans.Rollback();
                    return;
                }
                trans.Commit();
            }catch(Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
        }
        
    }
}

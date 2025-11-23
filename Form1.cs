namespace Urna._2026
{
    public partial class Apresentacao : Form
    {

        bool isBranco = false;
        int votos17 = 0;
        int votos13 = 0;
        int votos22 = 0;
        int votosBranco = 0;

        public Apresentacao()
        {
            InitializeComponent();
        }
        private void Apresentação_Load(object sender, EventArgs e)
        {

            Votação.Visible = false;
            FIM.Visible = false;
            Final_votacao.Visible = false;

        }

        private void Iniciando_votação_Click(object sender, EventArgs e)
        {

            Votação.Visible = true;
        }
        private void Num_1_Click(object sender, EventArgs e) => DigitarNumero("1");


        private void Num_2_Click(object sender, EventArgs e) => DigitarNumero("2");

        private void Num_3_Click(object sender, EventArgs e) => DigitarNumero("3");


        private void Num_4_Click(object sender, EventArgs e) => DigitarNumero("4");


        private void Num_5_Click(object sender, EventArgs e) => DigitarNumero("5");


        private void Num_6_Click(object sender, EventArgs e) => DigitarNumero("6");

        private void Num_7_Click(object sender, EventArgs e) => DigitarNumero("7");

        private void Num_8_Click(object sender, EventArgs e) => DigitarNumero("8");

        private void Num_9_Click(object sender, EventArgs e) => DigitarNumero("9");

        private void Num_0_Click(object sender, EventArgs e) => DigitarNumero("0");

        private void DigitarNumero(string numero)
        {
            if (lbl_n1.Text == "")
                lbl_n1.Text = numero;
            else if (lbl_n2.Text == "")
                lbl_n2.Text = numero;

            VerificarCandidato();
        }



        private void VerificarCandidato()
        {
            string numero = lbl_n1.Text + lbl_n2.Text;

            // Só verifica se os dois dígitos já foram preenchidos
            if (numero.Length < 2)
                return;

            switch (numero)
            {
                case "17":
                    lblNome.Text = "SCOOBY DOO";
                    lbl_partido.Text = "MISTÉRIO";
                    pictureBox1.Image = Image.FromFile(@"Urna_imagens/Scooby.jpg");
                    break;

                case "13":
                    lblNome.Text = "PICA PAU";
                    lbl_partido.Text = "HEHEHE";
                    pictureBox1.Image = Image.FromFile(@"Urna_imagens/Pica Pau Maluco.jpg");
                    break;

                case "22":
                    lblNome.Text = "PERNALONGA";
                    lbl_partido.Text = "VELHINHO ";
                    pictureBox1.Image = Image.FromFile(@"Urna_imagens/Perna longa.jpg");
                    break;

                default:
                    MessageBox.Show("Número inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Reseta tudo
                    lbl_n1.Text = "";
                    lbl_n2.Text = "";
                    lblNome.Text = "----";
                    lbl_partido.Text = "----";
                    pictureBox1.Image = null;
                    break;
            }
        }


        private void Confirmar_Click(object sender, EventArgs e)
        {
            string numero = lbl_n1.Text + lbl_n2.Text;

            // Se voto for branco
            if (isBranco)
            {
                votosBranco++;
                FIM.Visible = true;
                return;
            }

            // Se não digitou os 2 números:
            if (numero.Length < 2)
            {
                MessageBox.Show("Necessário preencher o voto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se número não existe:
            if (numero != "17" && numero != "13" && numero != "22")
            {
                MessageBox.Show("Número inexistente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Voto válido
            if (numero == "17") votos17++;
            else if (numero == "13") votos13++;
            else if (numero == "22") votos22++;

            FIM.Visible = true;
        }


        private void branco_Click(object sender, EventArgs e)
        {
            if (lbl_n1.Text != "" || lbl_n2.Text != "")
            {
                MessageBox.Show("Para votar BRANCO, não pode ter número digitado!",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lbl_n1.Text = "";
            lbl_n2.Text = "";
            lblNome.Text = "VOTO EM BRANCO";
            lbl_partido.Text = "";
            pictureBox1.Image = null;
            isBranco = true;
        }


        private void Corrigir_Click(object sender, EventArgs e)
        {
            lbl_n1.Text = "";
            lbl_n2.Text = "";
            lblNome.Text = "";
            lbl_partido.Text = "";
            pictureBox1.Image = null;
        }

        private void painel_nome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void painel_partido_Paint(object sender, PaintEventArgs e)
        {

        }


        private void painel_n1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void painel_n2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Nome_Click(object sender, EventArgs e)
        {

        }

        private void FIM_Paint(object sender, PaintEventArgs e)
        {

        }
        private void encerrar_Click(object sender, EventArgs e)
        {
            Final_votacao.Visible = true;
            MostrarResultado();
        }
        private void NOVO_VOTO_Click(object sender, EventArgs e)
        {
            // Limpa campos de votação
            lbl_n1.Text = "";
            lbl_n2.Text = "";
            lblNome.Text = "";
            lbl_partido.Text = "";
            pictureBox1.Image = null;
            isBranco = false;

            // Volta para a tela da urna
            FIM.Visible = false;
            Votação.Visible = false;   // <-- aqui o ajuste importante!;
        }

        private void Final_votacao_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MostrarResultado()
        {
            var ranking = new List<(string nome, int votos)>
    {
        ("SCOOBY DOO (17)", votos17),
        ("PICA PAU (13)", votos13),
        ("PERNALONGA (22)", votos22)
    };
            var branco = new List<(string nome, int votos)>
            {
                 ("BRANCO", votosBranco)
            };

            voto_branco.Text = $"{branco[0].nome}: {branco[0].votos}";

            ranking = ranking.OrderByDescending(r => r.votos).ToList();

            lbl_1L.Text = $"{ranking[0].nome}: {ranking[0].votos}";
            lbl_2L.Text = $"{ranking[1].nome}: {ranking[1].votos}";
            lbl_3L.Text = $"{ranking[2].nome}: {ranking[2].votos}";

            // Foto do vencedor
            if (ranking[0].nome.Contains("SCOOBY"))
                foto_vencedor.Image = Image.FromFile(@"Urna_imagens/Scooby.jpg");
            else if (ranking[0].nome.Contains("PICA"))
                foto_vencedor.Image = Image.FromFile(@"Urna_imagens/Pica Pau Maluco.jpg");
            else if (ranking[0].nome.Contains("PERNALONGA"))
                foto_vencedor.Image = Image.FromFile(@"Urna_imagens/Perna longa.jpg");
            else
                foto_vencedor.Image = null;

            foto_vencedor.Visible = true;


            // Verificar empates

            if (ranking[0].votos == 0 && ranking[1].votos == 0 && ranking[2].votos == 0)
            {
                lbl_1L.Text = "Sem votos";
                lbl_2L.Text = "Sem votos";
                lbl_3L.Text = "Sem votos";

                foto_vencedor.Visible = false;

                MessageBox.Show("Houve somente votos em branco", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (ranking[0].votos == ranking[1].votos && ranking[0].votos == ranking[2].votos)
                {                
                    lbl_1L.Text = "Empate";
                    lbl_2L.Text = "Empate";
                    lbl_3L.Text = "Empate";

                    foto_vencedor.Visible = false;
                    MessageBox.Show("Houve um empate entre todos os candidatos!", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (ranking[0].votos == ranking[1].votos)
                { 
                    lbl_1L.Text = "Empate";
                    lbl_2L.Text = "Empate";
                    foto_vencedor.Visible = false;
                    MessageBox.Show($"Houve um empate entre {ranking[0].nome} e {ranking[1].nome} com o total de {ranking[0].votos} ", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

        private void foto_vencedor_Click(object sender, EventArgs e)
        {

        }

        private void painel_votos1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_1L_Click(object sender, EventArgs e)
        {

        }

        private void painel_votos2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_2L_Click(object sender, EventArgs e)
        {

        }

        private void painel_votos3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void lbl_3L_Click(object sender, EventArgs e)
        {

        }

        private void NOVA_VOTAÇÃO_Click(object sender, EventArgs e)
        {
            votos17 = 0;
            votos13 = 0;
            votos22 = 0;
            votosBranco = 0;

            // Reset votos da urna
            lbl_n1.Text = "";
            lbl_n2.Text = "";
            lblNome.Text = "";
            lbl_partido.Text = "";
            pictureBox1.Image = null;
            isBranco = false;

            Final_votacao.Visible = false;
            FIM.Visible = false;
            Votação.Visible = false;
        }


        private void Partido13_Click(object sender, EventArgs e)
        {

        }

        private void podio2_Click(object sender, EventArgs e)
        {

        }

     
    }
}

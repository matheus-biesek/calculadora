using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atividade_6
{
    public partial class Form1 : Form
    {
        public void atualizarListaLog(string itemAdicional)
        {
            for (int i = 0; i < 19; i++)
            {
                listaHistorico[i] = listaHistorico[i + 1];
            }
            listaHistorico[19] = itemAdicional + " ; ";
        }

        public void salvaItemNaMemoria(int posicao)
        {
            listaResultado[posicao] = double.Parse(textBox1.Text);

            textBox2.Text = "";

            foreach (double elemente in listaResultado)
            {
                string item = elemente.ToString();

                textBox2.Text += item + " ; ";
            }

            selecionaTeclado = tipoTeclado.calculadora;
        }

        public void coletaItemDaMemoria(int posicao)
        {
            textBox1.Text = listaResultado[posicao].ToString();
            selecionaTeclado = tipoTeclado.calculadora;
        }

        public void processoTipoDoTeclado(int numeroTeclado)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    textBox1.Text += numeroTeclado;
                    break;

                case tipoTeclado.salvaMemoria:
                    salvaItemNaMemoria(numeroTeclado);
                    break;

                case tipoTeclado.coletaMemoria:
                    coletaItemDaMemoria(numeroTeclado);
                    break;

                default:
                    break;

            }
        }

        public void processoHistoricoOperacao(double valor, String operacao)
        {
            textBox1.Text = "";
            atualizarListaLog(valor.ToString());
            atualizarListaLog(" " + operacao + " ");
        }

        private enum tipoTeclado
        {
            salvaMemoria,
            coletaMemoria,
            calculadora,
        }
        private tipoTeclado selecionaTeclado { get; set; }

        private enum operacao
        {
            adicao,
            subtracao,
            multiplicacao,
            divisao,
            raiz_base,
            expo_base,
            raiz,
            expo,
            seno,
            cosseno,
            tangente,
            neutro
        }
        private operacao selecionaOperacao { get; set; }

        double valor;

        double[] listaResultado = new double[10];

        string[] listaHistorico = new string[20];

        public Form1()
        {
            InitializeComponent();

            selecionaTeclado = tipoTeclado.calculadora;

            selecionaOperacao = operacao.neutro;
        }

        private void button_n0_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(0);
        }

        private void button_n1_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(1);
        }

        private void button_n2_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(2);
        }

        private void button_n3_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(3);
        }

        private void button_n4_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(4);
        }

        private void button_n5_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(5);
        }

        private void button_n6_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(6);
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(7);
        }

        private void button_n8_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(8);
        }

        private void button_n9_Click(object sender, EventArgs e)
        {
            processoTipoDoTeclado(9);
        }

        private void button_virgula_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (!(textBox1.Text.Contains(",")))
                    {
                        textBox1.Text += ',';
                    }
                    break;

                default:
                    break;
            }
        }

        private void button_historico_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            foreach (string elemento in listaHistorico)
            {
                textBox2.Text += elemento;
            }
        }

        private void button_salva_valores_Click(object sender, EventArgs e)
        {
            selecionaTeclado = tipoTeclado.salvaMemoria;
            textBox2.Text = "";
            foreach (double elemento in listaResultado)
            {
                textBox2.Text += elemento.ToString() + " ; ";
            }
        }

        private void button_lista_resposta_Click(object sender, EventArgs e)
        {
            selecionaTeclado = tipoTeclado.coletaMemoria;
            textBox2.Text = "";

            foreach (double elemento in listaResultado)
            {
                textBox2.Text += elemento.ToString() + " ; ";
            }
        }

        private void button_tangente_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    selecionaOperacao = operacao.tangente;
                    atualizarListaLog(" Tan");
                    break;

                default:
                    break;
            }
        }

        private void button_seno_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    selecionaOperacao = operacao.seno;
                    atualizarListaLog(" Sen ");
                    break;

                default:
                    break;
            }
        }

        private void button_cosseno_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    selecionaOperacao = operacao.cosseno;
                    atualizarListaLog(" Cos ");
                    break;

                default:
                    break;
            }
        }

        private void button_expo_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    selecionaOperacao = operacao.expo;
                    atualizarListaLog(" ^2 ");
                    break;

                default:
                    break;

            }
        }

        private void button_raiz_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    selecionaOperacao = operacao.raiz;
                    atualizarListaLog(" √ ");
                    break;

                default:
                    break;

            }
        }

        private void button_adicao_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (double.TryParse(textBox1.Text, out valor))
                    {
                        selecionaOperacao = operacao.adicao;
                        processoHistoricoOperacao(valor, "+");
                    }
                    break;

                default:
                    break;

            }
        }

        private void button_subtracao_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (double.TryParse(textBox1.Text, out valor))
                    {
                        selecionaOperacao = operacao.subtracao;
                        processoHistoricoOperacao(valor, "-");
                    }
                    break;

                default:
                    break;
            }
        }

        private void button_multiplicacao_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (double.TryParse(textBox1.Text, out valor))
                    {
                        selecionaOperacao = operacao.multiplicacao;
                        processoHistoricoOperacao(valor, "*");
                    }
                    break;

                default:
                    break;
            }
        }

        private void button_dvisao_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (double.TryParse(textBox1.Text, out valor))
                    {
                        selecionaOperacao = operacao.divisao;
                        processoHistoricoOperacao(valor, "/");
                    }
                    break;

                default:
                    break;
            }
        }

        private void button_expo_base_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (double.TryParse(textBox1.Text, out valor))
                    {
                        selecionaOperacao = operacao.expo_base;
                        processoHistoricoOperacao(valor, "^");
                    }
                    break;

                default:
                    break;
            }
        }

        private void button_raiz_base_Click(object sender, EventArgs e)
        {
            switch (selecionaTeclado)
            {
                case tipoTeclado.calculadora:
                    if (double.TryParse(textBox1.Text, out valor))
                    {
                        selecionaOperacao = operacao.raiz_base;
                        processoHistoricoOperacao(valor, "√");
                    }
                    break;

                default:
                    break;
            }
        }

        public void processoHistoricoResultado(String resultado)
        {
            atualizarListaLog(textBox1.Text);
            atualizarListaLog(" = ");
            atualizarListaLog(resultado);
            textBox1.Text = resultado;
        }

        public void returnUserAddHistoricDoubleValue(String valorUm, String valorDois, String resultado, String operador)
        {
            textBox2.Text = valorUm + " " + operador + " " + valorDois + " = " + resultado;
            processoHistoricoResultado(resultado);
            
        }

        public void returnUserAddHistoricOneValue(String resultado, String operador)
        {
            textBox2.Text = " " + operador + " " + textBox1.Text + " = " + resultado;
            processoHistoricoResultado(resultado);
        }





        private void button_igual_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double valorAtual))
            {
                String valorUm;
                String valorDois;
                String resultado;
                double resultadoPontoFlutuante;
                switch (selecionaOperacao)
                {
                    case operacao.adicao:
                        valorUm = valor.ToString();
                        valorDois = textBox1.Text;
                        resultado = (valor + double.Parse(textBox1.Text)).ToString();
                        returnUserAddHistoricDoubleValue(valorUm, valorDois, resultado, "+");
                        break;

                    case operacao.subtracao:
                        valorUm = valor.ToString();
                        valorDois = textBox1.Text;
                        resultado = (valor - double.Parse(textBox1.Text)).ToString();
                        returnUserAddHistoricDoubleValue(valorUm, valorDois, resultado, "-");
                        break;

                    case operacao.divisao:
                        valorUm = valor.ToString();
                        valorDois = textBox1.Text;
                        resultado = (valor / double.Parse(textBox1.Text)).ToString();
                        returnUserAddHistoricDoubleValue(valorUm, valorDois, resultado, "/"); 
                        break;

                    case operacao.multiplicacao:
                        valorUm = valor.ToString();
                        valorDois = textBox1.Text;
                        resultado = (valor * double.Parse(textBox1.Text)).ToString();
                        returnUserAddHistoricDoubleValue(valorUm, valorDois, resultado, "*");
                        break;

                    case operacao.expo_base:
                        valorUm = valor.ToString();
                        valorDois = textBox1.Text;
                        resultado = Math.Pow(valor, double.Parse(textBox1.Text)).ToString();
                        returnUserAddHistoricDoubleValue(valorUm, valorDois, resultado, "^");
                        break;

                    case operacao.raiz_base:
                        valorUm = valor.ToString();
                        valorDois = textBox1.Text;
                        resultado = Math.Pow(valor, (1 / double.Parse(textBox1.Text))).ToString();
                        returnUserAddHistoricDoubleValue(valorUm, valorDois, resultado, "√");
                        break;

                    case operacao.raiz:
                        resultadoPontoFlutuante = Math.Sqrt(double.Parse(textBox1.Text));
                        resultado = resultadoPontoFlutuante.ToString();
                        returnUserAddHistoricOneValue(resultado, "√");
                        break;

                    case operacao.expo:
                        resultadoPontoFlutuante = Math.Pow(double.Parse(textBox1.Text), 2);
                        resultado = resultadoPontoFlutuante.ToString();
                        returnUserAddHistoricOneValue(resultado, "^2");
                        break;

                    case operacao.cosseno:
                        resultado = Math.Cos(double.Parse(textBox1.Text) * (Math.PI / 180)).ToString();
                        returnUserAddHistoricOneValue(resultado, "Cos");
                        break; 

                    case operacao.seno:
                        resultado = Math.Sin(double.Parse(textBox1.Text) * (Math.PI / 180)).ToString();
                        returnUserAddHistoricOneValue(resultado, "Sen");
                        break;

                    case operacao.tangente:
                        resultado = Math.Tan(double.Parse(textBox1.Text) * (Math.PI / 180)).ToString();
                        returnUserAddHistoricOneValue(resultado, "Tan");
                        break;

                    default:
                        break;
                }
                selecionaOperacao = operacao.neutro;
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            valor = 0;
            atualizarListaLog(textBox1.Text);
            textBox1.Text = "";
            selecionaOperacao = operacao.neutro;
            atualizarListaLog(" C ");
        }

        private void button_CE_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 19; i++)
            {
                listaHistorico[i] = listaHistorico[i + 1];
            }
            listaHistorico[19] = textBox1.Text + " ; ";
            for (int i = 0; i < 19; i++)
            {
                listaHistorico[i] = listaHistorico[i + 1];
            }
            listaHistorico[19] = " CE " + " ; ";
            textBox1.Text = "";
        }

        private void MC_zera_memoria_Click(object sender, EventArgs e)
        {
            listaResultado[0] = 0;
            textBox2.Text = "";
            foreach (double elemento in listaResultado)
            {
                string item = elemento.ToString();
                textBox2.Text += item + " ; ";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVelha
{
    public class Tabuleiro
    {
        //Representa o tabuleiro do jogo da velha
        private char[,] matriz;
        private int espacosLivres;//Controla quantas casas livres temos;
        private char jogadorDaVez; //Controla o jogador da Vez O ou X
        public enum Status {Empate =0,X=1,O=2,Continua=3}; // Enumeração utilizada para definir o resultado de cada movimento
        //Propriedade que retorna o jogador ativo
        public char JogadorDaVez
        {
            get { return jogadorDaVez; }
           
        }
        public Tabuleiro()
        {
            matriz = new char[3, 3];
            jogadorDaVez = ' ';
        }
        private char ProximoJogador()
        {
            if (jogadorDaVez == 'X')
                return 'O';
            else
                return 'X';
        }
        public void NovoJogo()
        {
            jogadorDaVez = ProximoJogador();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matriz[i, j] = ' ';
            espacosLivres = 9;
        }

        
        public bool Jogar(int linha, int coluna)
        {
            if (matriz[linha, coluna] == ' ')
            {
                matriz[linha, coluna] = jogadorDaVez;
                espacosLivres--;//Diminui o número de espaços livres
                return true;
            }
            return false;   
        }
        private Status VerificaJogador()
        {
            if (jogadorDaVez == 'X')
                return Status.X;
            else
                return Status.O;
        }
        public Status VerificarJogo()
        {
            //Verificar primeiro as linhas

            if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] && matriz[0,0]==jogadorDaVez)
            {
                return VerificaJogador();
            }
            else if (matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] && matriz[1,0]==jogadorDaVez)
            {
                return VerificaJogador();
            }
            else if (matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2] && matriz[2, 0] == jogadorDaVez)
            {
                return VerificaJogador();
            }
                //Verificar as colunas
            else if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] && matriz[0, 0] == jogadorDaVez)
            {
                return VerificaJogador();
            }
            else if (matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] && matriz[0, 1] == jogadorDaVez)
            {
                return VerificaJogador();
            }
            else if (matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2] && matriz[0, 2] == jogadorDaVez)
            {
                return VerificaJogador();
            }//Verifica as diagonais
            else if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] && matriz[0, 0] == jogadorDaVez)
            {
                return VerificaJogador();
            }
            else if(matriz[0,2]==matriz[1,1] && matriz[1,1]==matriz[2,0] && matriz[0,2]==jogadorDaVez)
            {
                return VerificaJogador();
            }
            else if(espacosLivres==0)
            {
                return Status.Empate;
            }
            else
            {
                return Status.Continua;
            }

        }


    }
}

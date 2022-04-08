namespace CadastroSeries
{
    public class Series:EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool ExcluirSerie {get; set;}

        //Método construtor da classe Series.
        public Series(int id,Genero genero, string titulo,string descricao, int ano)
        {
            this.IdEntidade = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.ExcluirSerie = false;
        }

        //Sobrescrita do método ToString para impressão de instacias da classe.
        public override string ToString()
        {
            string ImpressaoInstacia = "";
             this.ExcluirSerie = this.CorfirmacaoExclusao();
             string status = "";
             if(!this.ExcluirSerie)
             {
                 status = "Cadastrado";
             }
             else
             {
                 status = "EXcluído";
             }
        
            return ImpressaoInstacia += ($"Genero: {this.Genero + Environment.NewLine}Título: {this.Titulo + Environment.NewLine}Descrição: {this.Descricao + Environment.NewLine}Ano: {this.Ano + Environment.NewLine}Status: {status}");
        }

        public int RetornaIdSerie()
        {
            return this.IdEntidade;
        }

        public string RetornaTituloSerie()
        {
            return this.Titulo;
        }

        public void Excluir()
        {
            this.ExcluirSerie = true;
        }

        public bool CorfirmacaoExclusao()
        {
            return this.ExcluirSerie;
        }

        public void retornaStatus()
        {
            this.ExcluirSerie = this.CorfirmacaoExclusao();
             string status = "";
             if(!this.ExcluirSerie)
             {
                 status = "Cadastrado";
             }
             else
             {
                 status = "EXcluído";
             }
        }

    }
}
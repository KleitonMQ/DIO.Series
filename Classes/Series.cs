namespace DIOSeries
{
    public class Series : EntidadeBase
    {
        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.ID = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public override string ToString()
        {
            return $@"Genero = {this.Genero}
Titulo = {this.Titulo}
Descrição = {this.Descricao}
Ano de lançamento = {this.Ano}
Excluido = {this.Excluido}";
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public int RetornaID()
        {
            return this.ID;
        }
        public void Exciuir(){
            this.Excluido = true;
        }
    }
}


namespace Projeto_Acervo
{
    public enum Genero
    {
		Acao              = 1,
		Aventura          = 2,
		Comedia           = 3,
		Documentario      = 4,
		Drama             = 5,
		Espionagem        = 6,
		Faroeste          = 7,
		Fantasia          = 8,
		Ficcao_Cientifica = 9,
		Musical           = 10,
		Romance           = 11,
		Suspense          = 12,
		Terror            = 13 
    }

	public enum Acervo
	{
		Serie  = 1,
        Filme  = 2,
		Livro_em_Construção  = 3,
		Musica_em_Construção = 4  
	}

	public enum Operacao
	{
		Listar    = 1,
		Incluir   = 2,
		Atualizar = 3,
		Excluir   = 4,
		Consultar = 5
	}
}
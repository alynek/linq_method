using System.Collections.Generic;

namespace LinqMethods
{
    public class Filme
    {
        public int DiretorId { get; set; }
        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Minutos { get; set; }

        public List<Filme> ObtemFilmes()
        {
            return new List<Filme>
            {
                new Filme
                {
                    DiretorId = 1,
                    Diretor = new Diretor{Nome = "Quentin Tarantino"},
                    Titulo = "Cães de aluguel",
                    Ano = 1992,
                    Minutos = 99
                },
                new Filme
                {
                    DiretorId = 1,
                    Diretor = new Diretor{Nome = "Quentin Tarantino"},
                    Titulo = "Kill Bill",
                    Ano = 2003,
                    Minutos = 111
                }, 
                new Filme
                {
                    DiretorId = 1,
                    Diretor = new Diretor{Nome = "Quentin Tarantino"},
                    Titulo = "Era uma vez em Hollywood",
                    Ano = 2019,
                    Minutos = 171
                }, new Filme
                {
                    DiretorId = 2,
                    Diretor = new Diretor{Nome = "Christopher Nolan"},
                    Titulo = "Interestelar",
                    Ano = 2014,
                    Minutos = 169
                },
                new Filme
                {
                    DiretorId = 2,
                    Diretor = new Diretor{Nome = "Christopher Nolan"},
                    Titulo = "A origem",
                    Ano = 2010,
                    Minutos = 148
                }, 
                new Filme
                {
                    DiretorId = 2,
                    Diretor = new Diretor{Nome = "Christopher Nolan"},
                    Titulo = "Batman: O cavaleiro das trevas ressurge",
                    Ano = 2012,
                    Minutos = 165
                }, new Filme
                {
                    DiretorId = 3,
                    Diretor = new Diretor{Nome = "Stanley Kubrick"},
                    Titulo = "2001 - Uma Odisseia no Espaço",
                    Ano = 1968,
                    Minutos = 139
                }, 
                new Filme
                {
                    DiretorId = 3,
                    Diretor = new Diretor{Nome = "Stanley Kubrick"},
                    Titulo = "Laranja Mecânica",
                    Ano = 1971,
                    Minutos = 136
                },
                new Filme
                {
                    DiretorId = 3,
                    Diretor = new Diretor{Nome = "Stanley Kubrick"},
                    Titulo = "O iluminado",
                    Ano = 1980,
                    Minutos = 146
                },
                new Filme
                {
                    DiretorId = 4,
                    Diretor = new Diretor{Nome = "Steven Spielberg"},
                    Titulo = "A Lista de Schindler",
                    Ano = 1993,
                    Minutos = 195
                },
                new Filme
                {
                    DiretorId = 4,
                    Diretor = new Diretor{Nome = "Steven Spielberg"},
                    Titulo = "O Resgate do Soldado Ryan",
                    Ano = 1998,
                    Minutos = 170
                },
                new Filme
                {
                    DiretorId = 4,
                    Diretor = new Diretor{Nome = "Steven Spielberg"},
                    Titulo = "De Volta Para o Futuro",
                    Ano = 1985,
                    Minutos = 116
                },
                new Filme
                {
                    DiretorId = 4,
                    Diretor = new Diretor{Nome = "Steven Spielberg"},
                    Titulo = "Cavalo de guerra",
                    Ano = 2011,
                    Minutos = 146
                },
                new Filme
                {
                    DiretorId = 5,
                    Diretor = new Diretor{Nome = "Francis Ford Coppola"},
                    Titulo = "O poderoso chefão",
                    Ano = 1972,
                    Minutos = 175
                },
                new Filme
                {
                    DiretorId = 5,
                    Diretor = new Diretor{Nome = "Francis Ford Coppola"},
                    Titulo = "Drácula de Bram Stoker",
                    Ano = 1992,
                    Minutos = 127
                },
                new Filme
                {
                    DiretorId = 5,
                    Diretor = new Diretor{Nome = "Francis Ford Coppola"},
                    Titulo = "O poderoso chefão parte II",
                    Ano = 1974,
                    Minutos = 202
                }
            };
        }
    }

    public class Diretor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IList<Diretor> ObtemDiretores()
        {
            return new List<Diretor>
            {
                new Diretor { Id = 1, Nome = "Quentin Tarantino" },
                new Diretor { Id = 2, Nome = "Christopher Nolan" },
                new Diretor { Id = 3, Nome = "Stanley Kubrick" },
                new Diretor { Id = 4, Nome = "Steven Spielberg" },
                new Diretor { Id = 5, Nome = "Francis Ford Coppola" }
            };
        }
    }
}

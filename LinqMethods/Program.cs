using System.Collections.Generic;
using System.Linq;
using System;

namespace LinqMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                numeros.Add(i);
            }

            //Filtrando números com Where usando sintaxe de método
            var numerosMaioresQueSessenta = numeros.Where(n => n > 60).ToList();



            numerosMaioresQueSessenta.ForEach(n => Console.Write($"{n},"));
            Console.WriteLine("\n");


            //Filtrando números com Where usando sintaxe de consulta
            var numerosMenoresQueCinco = from n in numeros
                                         where n < 5
                                         select n;


            numerosMenoresQueCinco.ToList().ForEach(n => Console.Write($"{n},"));
            Console.WriteLine("\n");


            //Soma os valores dentro do array...é preciso ser uma estrutura de dados do tipo numérica (int, double, float, long)
            Console.WriteLine("Soma de todos os elementos do array: " + numerosMenoresQueCinco.Sum());


            Console.WriteLine("Quantidade de elementos no array: " + numerosMenoresQueCinco.Count());


            Console.WriteLine("Menor elemento do array: " + numerosMenoresQueCinco.Min());


            Console.WriteLine("Maior elemento do array: " + numerosMenoresQueCinco.Max());


            Console.WriteLine("Média dos números: " + numerosMaioresQueSessenta.Average());


            //Pegando os 4 primeiros números dentro do array e somando eles
            Console.WriteLine("A soma dos 4 primeiros números: " + numeros.Take(numeros.Count).Sum());


            //Pegando os 4 primeiros números e concatenando com a lista de números menores que cinco
            numeros.Take(4).Concat(numeros.TakeLast(5)).ToList().ForEach(n => Console.Write(n + ","));
            Console.WriteLine("\n");


            Console.WriteLine("Somandos os próximos 60 números: " + numeros.Skip(40).Sum());

            //Criado um range de 50 posições...com o range começando em 10, ou seja, de 10 a 59
            Console.WriteLine(Enumerable.Range(10, 50).Reverse().Take(3).Last());



            //Fazendo consultas em estruturas de dados do tipo Dictionary
            var personagens = new Dictionary<string, string>()
            {
                { "Gandalf", "Feitiço" },
                { "Bilbo", "Invisibilidade"},
                { "Legolas", "Arquearia" },
                { "Sam", "Coragem" },
                { "Frodo", "Coragem" },
                { "Saruman", "Feitiço" },
            };

            var leg1 = personagens.Where(nome => nome.Key.Contains("a")).ToList();
            var leg2 = personagens.FirstOrDefault(nome => nome.Key.StartsWith("Leg"));

            foreach (var item in leg1)
            {
                Console.WriteLine($"Nome: {item.Key}, Skill: {item.Value}");
            }

            Console.WriteLine($"Nome: {leg2.Key}, Skill: {leg2.Value}");

            //Usando LastOrDefault para trazer a última ocorrência
            var ultimoPersonagemComFeitico = personagens.LastOrDefault(skill => skill.Value.Contains("Feitiço")).Key;
            Console.WriteLine(ultimoPersonagemComFeitico);


            //Ordenando a lista pelo nome do personageme e skill de Coragem
            var coragemOrdenada = personagens.Where(p => p.Value.Contains("Coragem")).OrderBy(p => p.Key).ToList();
            coragemOrdenada.ForEach(n => Console.Write($"Nome: {n.Key}, Skill: {n.Value}\n"));


            //Ordenando a lista em ordem decrescente e criando um novo objeto anônimo
            var personagensOrdenadosPorNomeDecrescente = personagens.OrderByDescending(p => p.Key).Select(p => new { Id = Guid.NewGuid(), Nome = p.Key });
            foreach (var p in personagensOrdenadosPorNomeDecrescente)
            {
                Console.WriteLine(p);
            }




            //Usando Join para juntar duas tabelas 
            var filmes = new Filme().ObtemFilmes();
            var diretores = new Diretor().ObtemDiretores();

            var juncaoDeTabelas = filmes.Join(diretores,
                                     f => f.DiretorId,
                                     d => d.Id,
                                     (f, d) => new
                                     {
                                         f.Titulo,
                                         f.Ano,
                                         d.Nome
                                     }).Where(d => d.Nome.Contains("Tarantino")).ToList();

            juncaoDeTabelas.ForEach(j => Console.Write($"{j},\n"));


            //Usando Join com sintaxe de consulta
            var juncaoDeTabelasComJoin = from f in filmes
                                         join d in diretores
                                         on f.DiretorId equals d.Id
                                         where f.Ano < 2000
                                         orderby f.Ano ascending
                                         select new
                                         {
                                             f.Titulo,
                                             f.Ano,
                                             d.Nome
                                         };
            juncaoDeTabelasComJoin.ToList().ForEach(j => Console.WriteLine($"{j.Titulo}, {j.Ano}, {j.Nome}"));



            //Agrupando os filmes
            var mediaDeDuracaoDosFilmes = filmes.GroupBy(f => f.Minutos).Select(f => f.Key).Average();
            //Console.WriteLine("Média dos filmes: " + mediaDeDuracaoDosFilmes);




            var juncaoDeTabelasComGroupBy = filmes.Join(diretores,
                                    f => f.DiretorId,
                                    d => d.Id,
                                    (f, d) => new
                                    {
                                        f.Titulo,
                                        f.Ano,
                                        d.Nome
                                    }).Where(d => d.Ano < 2000).ToList()
                                    .GroupBy(f => new { f.Titulo, f.Ano, f.Nome })
                                    .ToList();

            juncaoDeTabelasComGroupBy.ForEach(j => Console.Write($"{j.Key.Titulo},\n"));
            Console.WriteLine();
            juncaoDeTabelasComGroupBy.ForEach(j => Console.Write($"{ j.Key.Ano},\n"));

            var diretorDaPosicao15 = numeros.ElementAtOrDefault(150);
            Console.WriteLine(diretorDaPosicao15);



            diretores.Clear();
            var diretoresEstaoVazios = diretores.DefaultIfEmpty(new Diretor { Id = 6, Nome = "Chris Columbus" }).ToList();
            Console.WriteLine(diretoresEstaoVazios.SingleOrDefault().Nome);



            //Usando TakeWhile
            var filmesDoSpielberg = filmes.Skip(9).TakeWhile(filme => filme.Diretor.Nome.Contains("Steven")).ToList();
            filmesDoSpielberg.ForEach(f => Console.WriteLine($"{f.Titulo}, {f.Diretor.Nome}"));
        }
    }
}

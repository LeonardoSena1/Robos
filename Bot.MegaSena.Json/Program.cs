using Newtonsoft.Json;
using System;
using System.Net;

namespace Bot.MegaSena.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o número do concurso:");
            string numeroDoConcurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numeroDoConcurso))
            {
                numeroDoConcurso = "2270";
            }            

            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1592443988325&concurso=" + numeroDoConcurso;

            string json;

            //Uso da documentação
            using (WebClient wv = new WebClient())
            {
                wv.Headers["Cookie"] = "security=true";
                json = wv.DownloadString(url);
            }

            var resultadoJson = JsonConvert.DeserializeObject<Resultado.RootObjects>(json);

            Console.WriteLine("Resultado do sorteio " + string.Format("{0:0,0.00}", resultadoJson.vr_estimativa));

            Console.WriteLine("Cidade " + resultadoJson.no_cidade);

            Console.WriteLine("Data do sorteio " + resultadoJson.dataStr);
        }
    }
}

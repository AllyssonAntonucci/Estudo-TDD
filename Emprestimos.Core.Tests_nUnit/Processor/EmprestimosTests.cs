using Emprestimos.Core.Domain;
using Emprestimos.Core.Processor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimos.Core.Tests_nUnit.Processor
{
    public class EmprestimosTests
    {
        EmprestimoProcessor _processor;

        [SetUp]
        public void Setup()
        {
            _processor = new EmprestimoProcessor();
        }

        [Test]
        public void DeveRetornarDadosEmprestimosComValoresDaRequisicao()
        {
            //organizar requisição
            var req = new EmprestimoReq()
            {
                PrimeiroNome = "NomedoUsuário",
                UltimoNome = "UltimoNomedoUsuário",
                Email = "usuario@usuario.com",
                Data = DateTime.Now
            };

            //processar a requisição e retornar o resultado
            EmprestimoResult result = _processor.LerDados(req);

            //Afirmação
            Assert.IsNotNull(result);
            Assert.That(result.PrimeiroNome, Is.EqualTo(req.PrimeiroNome));
            Assert.That(result.UltimoNome, Is.EqualTo(req.UltimoNome));
            Assert.That(result.Email, Is.EqualTo(req.Email));
            Assert.That(result.Data, Is.EqualTo(req.Data));
        }

        [Test]
        public void DeveRetornarUmaExceptionSeReqForNula()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.LerDados(null));
            Assert.That(exception.ParamName, Is.EqualTo("req"));
        }
    }
}

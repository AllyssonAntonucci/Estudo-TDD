using Emprestimos.Core.Domain;
using Emprestimos.Core.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Emprestimos.Core.Tests.Processor
{
    public class EmprestimosTests
    {
        EmprestimoProcessor _processor;
        public EmprestimosTests()
        {
            _processor = new EmprestimoProcessor();
        }

        [Fact]
        public void DeveRetornarDadosEmprestimosComValoresDaRequisicao()
        {
            // Organizar a requisição
            var req = new EmprestimoReq()
            {
                PrimeiroNome = "NomedoUsuário",
                UltimoNome = "UltimoNomedoUsuário",
                Email = "usuario@usuario.com",
                Data = DateTime.Now
            };

            // Processar a requisição e retornar o resultado
            EmprestimoResult result = _processor.LerDados(req);

            // Afirmação
            Assert.NotNull(result);
            Assert.Equal(req.PrimeiroNome, result.PrimeiroNome);
            Assert.Equal(req.UltimoNome, result.UltimoNome);
            Assert.Equal(req.Email, result.Email);
            Assert.Equal(req.Data, result.Data);
        }

        [Fact]
        public void DeveRetornarUmaExceptionSeReqForNula()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.LerDados(null));
            Assert.Equal("req", exception.ParamName);
        }
    }
}

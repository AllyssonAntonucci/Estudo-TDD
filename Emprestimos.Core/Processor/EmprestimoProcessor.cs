using Emprestimos.Core.Domain;

namespace Emprestimos.Core.Processor
{
    public class EmprestimoProcessor
    {
        public EmprestimoResult LerDados(EmprestimoReq req)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            return new EmprestimoResult
            {
                Data = req.Data,
                Email = req.Email,
                PrimeiroNome = req.PrimeiroNome,
                UltimoNome = req.UltimoNome,
            };
        }
    }
}
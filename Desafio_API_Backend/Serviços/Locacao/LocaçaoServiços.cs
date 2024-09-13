using Desafio_API_Backend.Data;
using Desafio_API_Backend.Dto;
using Desafio_API_Backend.Dto_Moto.locaçao;
using Desafio_API_Backend.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API_Backend.Serviços.Locacao
{
    public class LocaçaoServiços : LocaçaoInterface
    {
        private readonly ContextoBancoDeDados _contexto;

        //dando acesso ao banco de dados (ContextoBancoDeDados)
        public LocaçaoServiços(ContextoBancoDeDados contexto)
        {
            _contexto = contexto;
        }

        public async Task<ModeloDeResposta<List<ModeloLocaçao>>> CadastrarLocacao(LocaçaoCriaçaoDto locaçaoCriaçaoDto)
       
        {
            ModeloDeResposta<List<ModeloLocaçao>> resposta = new ModeloDeResposta<List<ModeloLocaçao>>();

            try
            {
                // Procura pela moto no banco de dados usando o IdMoto do DTO de criação
                var moto = await _contexto.Motos.FirstOrDefaultAsync(motoBanco => motoBanco.Id == locaçaoCriaçaoDto.IdMoto);

                if (moto == null)
                {
                    resposta.Mensagem = "Não foi possível registrar a locação: Nenhuma moto encontrada com o ID especificado.";
                    return resposta;
                }

                // Cria uma nova locação
                var locaçao = new ModeloLocaçao()
                {
                    DataLocao = locaçaoCriaçaoDto.DataLocao,
                    IdMoto = locaçaoCriaçaoDto.IdMoto,
                };

                // Adiciona a locação ao contexto e salva as mudanças
                _contexto.Add(locaçao);
                await _contexto.SaveChangesAsync();

                resposta.Dados = await _contexto.locacaos.Include(l => l.MotoRelacionada).ToListAsync();
                resposta.Mensagem = "Locação cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }

            return resposta;
        }

    }
}

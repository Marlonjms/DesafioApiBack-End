using Desafio_API_Backend.Data;
using Desafio_API_Backend.Dto;
using Desafio_API_Backend.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Desafio_API_Backend.Serviços.Moto
{
    public class MotoServiços : MotoInterface
    {


        private readonly ContextoBancoDeDados _contexto;
        //dando acesso ao banco de dados (ContextoBancoDeDados)
        public MotoServiços(ContextoBancoDeDados contexo)
        {

            _contexto = contexo;

        }



        //post cadastrar motos
        public async Task<ModeloDeResposta<List<ModeloMoto>>> CadastrarMoto(MotoCriaçaoDto motoCriaçãoDto)
        {
            ModeloDeResposta<List<ModeloMoto>> resposta = new ModeloDeResposta<List<ModeloMoto>>();

            try
            {
                // Verifica se já existe uma moto com a mesma placa
                var motoExistente = await _contexto.Motos
                    .FirstOrDefaultAsync(m => m.Placa == motoCriaçãoDto.Placa);

                if (motoExistente != null)
                {
                    resposta.Mensagem = "Já existe uma moto com a mesma placa cadastrada.";
                    resposta.Status = false;
                    return resposta;
                }

                // Se não existir, cria e adiciona a nova moto
                var moto = new ModeloMoto()
                {
                    Ano = motoCriaçãoDto.Ano,
                    Modelo = motoCriaçãoDto.Modelo,
                    Placa = motoCriaçãoDto.Placa,
                };

                _contexto.Motos.Add(moto);
                await _contexto.SaveChangesAsync();

                resposta.Dados = await _contexto.Motos.ToListAsync();
                resposta.Mensagem = "Moto cadastrada com sucesso!";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }

            return resposta;
        }





        //get buscar por placa
        public async Task<ModeloDeResposta<ModeloMoto>> BuscarPorPlaca(string placa)
        {
            ModeloDeResposta<ModeloMoto> resposta = new ModeloDeResposta<ModeloMoto>();

            try
            {
                // Busca a moto no banco de dados pela placa informada
                var moto = await _contexto.Motos.FirstOrDefaultAsync(motoBanco => motoBanco.Placa == placa);

                if (moto == null)
                {
                    // Moto não encontrada
                    resposta.Mensagem = "Nenhuma moto localizada!";
                    resposta.Status = false; // Adiciona o status falso para indicar falha
                    return resposta;
                }

                // Moto encontrada
                resposta.Dados = moto;
                resposta.Mensagem = "Moto localizada!";
                resposta.Status = true; // Define o status como true para sucesso
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }



        //get buscar todas as motos
        public async Task<ModeloDeResposta<List<ModeloMoto>>> ListarTodasMotos()
        {

            ModeloDeResposta<List<ModeloMoto>> resposta = new ModeloDeResposta<List<ModeloMoto>>();

            // tratamento de erros: 
            // vamos tentar realizar uma operação...
            try
            {

                var Motos = await _contexto.Motos.ToListAsync();

                resposta.Dados = Motos;
                resposta.Mensagem = "todas as motos foram listadas!";

                return resposta;



            }
            // se não e certo cairemos aqui!
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;


            }

        }



        // put, editando motos
        public async Task<ModeloDeResposta<List<ModeloMoto>>> EditarPlaca(MotoEdiçaoDto motoEdiçãoDto)
        {
            ModeloDeResposta<List<ModeloMoto>> resposta = new ModeloDeResposta<List<ModeloMoto>>();

            try
            {
                var moto = await _contexto.Motos.FirstOrDefaultAsync(motoBanco => motoBanco.Id == motoEdiçãoDto.Id);

                if (moto == null)
                {
                    resposta.Mensagem = "Nenhuma moto localizada!";
                    return resposta;
                }

                moto.Placa = motoEdiçãoDto.Placa;

                _contexto.Update(moto);
                await _contexto.SaveChangesAsync();

                resposta.Dados = await _contexto.Motos.ToListAsync();
                resposta.Mensagem = "Placa da moto editada com sucesso!";
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }

            return resposta;
        }


        // Del, remolvendo motos

       
        public async Task<ModeloDeResposta<List<ModeloMoto>>> ExcluirMoto(int idMoto)
        {
            ModeloDeResposta<List<ModeloMoto>> resposta = new ModeloDeResposta<List<ModeloMoto>>();

            try
            {
                // Encontrar a moto pelo ID
                var moto = await _contexto.Motos
                    .Include(m => m.Alocacoes) // Inclui as locações associadas
                    .FirstOrDefaultAsync(motoBanco => motoBanco.Id == idMoto);

                if (moto == null)
                {
                    resposta.Mensagem = "Nenhuma moto localizada!";
                    return resposta;
                }

                // Verificar se há locações associadas à moto
                if (moto.Alocacoes.Any())
                {
                    resposta.Mensagem = "A moto não pode ser removida porque possui locações associadas!";
                    resposta.Status = false;
                    return resposta;
                }

                // Remover a moto se não houver locações
                _contexto.Motos.Remove(moto);
                await _contexto.SaveChangesAsync();

                resposta.Dados = await _contexto.Motos.ToListAsync();
                resposta.Mensagem = "Moto removida com sucesso!";
                resposta.Status = true;
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
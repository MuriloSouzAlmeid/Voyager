﻿using Microsoft.EntityFrameworkCore;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class VisualizarAvaliacoes : IVisualizarAvaliacoes
    {
        private readonly VoyagerContext ctx;

        public VisualizarAvaliacoes()
        {
            ctx = new VoyagerContext();
        }

        public Avaliacoes BuscarPorId(Guid IdUsuario, Guid IdPostagem)
        {
            Avaliacoes avaliacaoBuscada = ctx.Avaliacoes.FirstOrDefault(a => a.IdUsuario == IdUsuario && a.IdPostagemViagem == IdPostagem)!;

            if(avaliacaoBuscada == null)
            {
                return null;
            }

            return avaliacaoBuscada;
        }

        public Avaliacoes BuscarPorPostUsuario(Guid IdUsuario, Guid IdPostagem)
        {
            Avaliacoes avaliacaoBuscada = ctx.Avaliacoes.FirstOrDefault(a => a.IdUsuario == IdUsuario && a.IdPostagemViagem == IdPostagem)!;

            return avaliacaoBuscada;
        }

        public List<Avaliacoes> BuscarPorUsuario(Guid idUsuario)
        {
            List<Avaliacoes> avaliacoes = ctx.Avaliacoes.Include(a => a.PostagemViagem)
                .Include(a => a.PostagemViagem.GaleriaImagens)
                .Include(a => a.PostagemViagem.Viagem.Usuario)
                .Where(a => a.IdUsuario == idUsuario)
                .OrderByDescending(a => a.DataAvaliacao).ToList();

            return avaliacoes;
        }

        public void Cadastrar(Avaliacoes novaAvaliacao)
        {
            try
            {
                ctx.Avaliacoes.Add(novaAvaliacao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Avaliacoes avaliacao)
        {
            if(avaliacao != null)
            {
                ctx.Avaliacoes.Remove(avaliacao);

                ctx.SaveChanges();
            }
        }

        public bool VerificarCurtidoDescurtido(Guid idUsuario, Guid idPostagem)
        {
            Avaliacoes avaliacao = BuscarPorPostUsuario(idUsuario, idPostagem);

            if (avaliacao != null)
            {
                if(avaliacao.StatusAvaliacao == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

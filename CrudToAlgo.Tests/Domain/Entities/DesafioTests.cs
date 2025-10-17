using Xunit;
using FluentAssertions;
using CrudToAlgo.Domain.Entities;

namespace CrudToAlgo.Tests.Domain.Entities
{
    public class DesafioTests
    {
        [Fact]
        public void Desafio_DeveTerValoresPadrao()
        {
            // Act
            var desafio = new Desafio();

            // Assert
            desafio.Dificuldade.Should().Be("Facil");
            desafio.Ativo.Should().BeTrue();
            desafio.CasosTeste.Should().NotBeNull();
            desafio.CasosTeste.Should().BeEmpty();
        }

        [Fact]
        public void Desafio_DevePermitirConfiguracaoPropriedades()
        {
            // Arrange & Act
            var desafio = new Desafio
            {
                Id = 1,
                Titulo = "Teste de Soma",
                Descricao = "Some dois números",
                Dificuldade = "Medio",
                Ativo = false
            };

            // Assert
            desafio.Id.Should().Be(1);
            desafio.Titulo.Should().Be("Teste de Soma");
            desafio.Descricao.Should().Be("Some dois números");
            desafio.Dificuldade.Should().Be("Medio");
            desafio.Ativo.Should().BeFalse();
        }
    }
}
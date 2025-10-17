using Xunit;
using FluentAssertions;
using CrudToAlgo.Domain.Entities;

namespace CrudToAlgo.Tests.Domain.Entities
{
    public class SubmissaoTests
    {
        [Fact]
        public void Submissao_DeveTerValoresPadrao()
        {
            // Act
            var submissao = new Submissao();

            // Assert
            submissao.Id.Should().Be(0);
            submissao.DesafioId.Should().Be(0);
            submissao.UsuarioId.Should().Be(0);
            submissao.Linguagem.Should().Be("csharp");
            submissao.Status.Should().Be("Pendente");
            submissao.PontosGanho.Should().Be(0);
            submissao.DataEnvio.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void Submissao_DevePermitirConfiguracaoPropriedades()
        {
            // Arrange
            var dataEnvio = DateTime.UtcNow.AddMinutes(-10);

            // Act
            var submissao = new Submissao
            {
                Id = 1,
                DesafioId = 10,
                UsuarioId = 5,
                Linguagem = "python",
                Codigo = "print('Hello World')",
                DataEnvio = dataEnvio,
                Status = "Aprovado",
                PontosGanho = 100
            };

            // Assert
            submissao.Id.Should().Be(1);
            submissao.DesafioId.Should().Be(10);
            submissao.UsuarioId.Should().Be(5);
            submissao.Linguagem.Should().Be("python");
            submissao.Codigo.Should().Be("print('Hello World')");
            submissao.DataEnvio.Should().Be(dataEnvio);
            submissao.Status.Should().Be("Aprovado");
            submissao.PontosGanho.Should().Be(100);
        }

        [Theory]
        [InlineData("csharp")]
        [InlineData("python")]
        [InlineData("java")]
        [InlineData("javascript")]
        public void Submissao_DeveAceitarLinguagensValidas(string linguagem)
        {
            // Act
            var submissao = new Submissao { Linguagem = linguagem };

            // Assert
            submissao.Linguagem.Should().Be(linguagem);
        }

        [Theory]
        [InlineData("Pendente")]
        [InlineData("Rodando")]
        [InlineData("Aprovado")]
        [InlineData("Rejeitado")]
        public void Submissao_DeveAceitarStatusValidos(string status)
        {
            // Act
            var submissao = new Submissao { Status = status };

            // Assert
            submissao.Status.Should().Be(status);
        }

        [Fact]
        public void Submissao_DevePermitirCodigoVazio()
        {
            // Act
            var submissao = new Submissao { Codigo = "" };

            // Assert
            submissao.Codigo.Should().BeEmpty();
        }

        [Fact]
        public void Submissao_DevePermitirPontosNegativos()
        {
            // Act
            var submissao = new Submissao { PontosGanho = -10 };

            // Assert
            submissao.PontosGanho.Should().Be(-10);
        }
    }
}
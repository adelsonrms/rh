﻿#region "Namepaces do Sistema"

using ERP.RH.Domain;
using ERP.Shared.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;


//Expoe entidades genericas

#endregion

namespace RH.Domain.Entities
{
    /// <summary>
    ///     Representa um Funcionario da empresa.
    ///     Um Funcionario herda de uma pessoa genericamente.
    ///     Para um funcionário, no entanto, é necessário especificar algumas informações adicionais como por ex
    ///     Contatos, Dados Cadastrais
    /// </summary>
    [Table("TPA.Funcionario")]
    public class Funcionario : EFEntity
    {
        public Funcionario()
        {
            Contrato = new Contrato();
            Documento  = new Documento();
            EstadoCivil = new EstadoCivil();
        }

        #region propriedades públicas
        public virtual string Matricula { get; set; }
        public virtual string CPF { get; set; }
        public virtual string PIS { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Celular { get; set; }
        public virtual string EmailProfissional { get; set; }
        public virtual string EmailPessoal { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string CEP { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual int SexoId { get; set; }
        public string Idade { get; set; }
        public virtual bool Ativo { get; set; }
        [Column("Contrato_Id")]
        public virtual Contrato Contrato { get; set; }
        [Column("Documento_Id")]
        public virtual Documento Documento { get; set; }
        [Column("EstadoCivil_Id")]
        public virtual EstadoCivil EstadoCivil { get; set; }
        [Column("Nome")]
        public Nome NomeDoFuncionario { get => new Nome(this.Nome); }

        

        #endregion
    }
}
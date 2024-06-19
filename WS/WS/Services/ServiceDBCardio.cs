using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using WS.Models;
using Xamarin.Forms;

namespace WS.Services
{
    public class ServiceDBCardio
    {
        SQLiteConnection conn;


        public string StatusMessage { get; set; }
        public ServiceDBCardio(string dbPath)
        {
            if (dbPath == "")
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Pressao>();
        }
        public void Inserir(Pressao pressao)
        {
            try
            {
                if (string.IsNullOrEmpty(pressao.Sistole.ToString()))
                    throw new Exception("Por Favor, Insira o valor para Sístole");
                if (string.IsNullOrEmpty(pressao.Diastole.ToString()))
                    throw new Exception("Por Favor, Insira o valor para Diástole");
                int result = conn.Insert(pressao);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("Valores da Pressão Inseridos com Sucesso");
                }
                else
                {
                    this.StatusMessage = string.Format("Não foi possível Inserir os valores da Pressão");
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public List<Pressao> Listar()
        {
            List<Pressao> lista = new List<Pressao>();
            try
            {
                lista = conn.Table<Pressao>().ToList(); 

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return lista;
        }
        public double  MediaSis()
        {
            try
            {
                string sql = "SELECT AVG(Sistole) AS MediaSis FROM PressaoArterial";
                var result = conn.ExecuteScalar<double>(sql);
                return result;

            }
            catch (Exception er) 
            {
                throw new Exception(er.Message);
            }
        }
        public double MediaDias()
        {
            try
            {
                string sql = "SELECT AVG(Diastole) AS MediaDias FROM PressaoArterial";
                var result = conn.ExecuteScalar<double>(sql);
                return result;

            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

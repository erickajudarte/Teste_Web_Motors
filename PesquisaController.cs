using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Projeto_WebMotors.Controllers
{
    public class PesquisaController : Controller
    {
        // GET: Pesquisa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult index_NovoAnuncio()
        {
            return View();
        }
        public ActionResult index_Edit()
        {
            return View();
        }

        public class Retorno_Lista
        {
            public string ID { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Versao { get; set; }
            public string Ano { get; set; }
            public string klm { get; set; }
            public string Obs { get; set; }
        }

        public JsonResult Pag_Pesquisa()
        {
            var comando = new SqlCommand();
            comando.Connection = Conexao.connection;
            comando.CommandText = "SEL_DADOS_ANUNCIO";

           // comando.Parameters.AddWithValue("@id",id);
            Conexao.Conectar();

            var i = 0;
            var reader = comando.ExecuteReader();
            var Result = new List<Retorno_Lista>();
            while (reader.Read())
            {

                Result.Add(new Retorno_Lista()
                {
                    ID = Convert.ToString(reader["ID"]),
                    Marca = Convert.ToString(reader["marca"]),
                    Modelo = Convert.ToString(reader["modelo"]),
                    Versao = Convert.ToString(reader["versao"]),
                    Ano = Convert.ToString(reader["ano"]),
                    klm = Convert.ToString(reader["quilometragem"]),
                    Obs = Convert.ToString(reader["observacao"])
                });
            }

            Conexao.Desconectar();

            var json = JsonConvert.SerializeObject(Result);             
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Inserir_Dados(string marca, string modelo, string versao,string ano, string klm, string obs)
        {
            var comando = new SqlCommand();
            comando.Connection = Conexao.connection;
            comando.CommandText = "INS_ANUNCIO  @marca,@modelo,@versao,@ano,@klm,@obs";
            comando.Parameters.AddWithValue("@marca",marca);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@versao", versao);
            comando.Parameters.AddWithValue("@ano", Convert.ToInt32(ano));
            comando.Parameters.AddWithValue("@klm", Convert.ToInt32(klm));
            comando.Parameters.AddWithValue("@obs", obs);



            // comando.Parameters.AddWithValue("@id",id);
            Conexao.Conectar();
            var reader = comando.ExecuteReader();
           
            Conexao.Desconectar();
            return Json("Inserido", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Busca_Editar(string id)
        {
            var comando = new SqlCommand();
            comando.Connection = Conexao.connection;
            comando.CommandText = "SEL_DADOS_ANUNCIO @ID";
            comando.Parameters.AddWithValue("@ID",Convert.ToInt32(id));
            // comando.Parameters.AddWithValue("@id",id);
            Conexao.Conectar();

            var reader = comando.ExecuteReader();
            var Result = new List<Retorno_Lista>();
            while (reader.Read())
            {
                Result.Add(new Retorno_Lista()
                {
                    ID = Convert.ToString(reader["ID"]),
                    Marca = Convert.ToString(reader["marca"]),
                    Modelo = Convert.ToString(reader["modelo"]),
                    Versao = Convert.ToString(reader["versao"]),
                    Ano = Convert.ToString(reader["ano"]),
                    klm = Convert.ToString(reader["quilometragem"]),
                    Obs = Convert.ToString(reader["observacao"])
                });
            }
            foreach (var item in Result)
            {
                ViewBag.ID = item.ID;
                ViewBag.Marca = item.Marca;
                ViewBag.Modelo = item.Modelo;
                ViewBag.Versao = item.Versao;
                ViewBag.Ano = item.Ano;
                ViewBag.klm = item.klm;
                ViewBag.Obs = item.Obs;
            };

            Conexao.Desconectar();

            
            return View("~/Views/Pesquisa/index_Edit.cshtml");
        }

        public JsonResult Editar_Dados(string id, string marca, string modelo, string versao, string ano, string klm, string obs)
        {
            var comando = new SqlCommand();
            comando.Connection = Conexao.connection;
            comando.CommandText = "UPD_ANUNCIO @ID,@marca,@modelo,@versao,@ano,@klm,@obs";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@versao", versao);
            comando.Parameters.AddWithValue("@ano", Convert.ToInt32(ano));
            comando.Parameters.AddWithValue("@klm", Convert.ToInt32(klm));
            comando.Parameters.AddWithValue("@obs", Convert.ToString(obs));



            // comando.Parameters.AddWithValue("@id",id);
            Conexao.Conectar();
            var reader = comando.ExecuteReader();

            Conexao.Desconectar();
            return Json("Inserido", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deletar_Dados(string id)
        {
            var comando = new SqlCommand();
            comando.Connection = Conexao.connection;
            comando.CommandText = "DEL_ANUNCIO  @id";
            comando.Parameters.AddWithValue("@id", Convert.ToInt32(id));


            Conexao.Conectar();
            var reader = comando.ExecuteReader();

            Conexao.Desconectar();
            return View("~/Views/Pesquisa/index.cshtml");
        }

        //public ActionResult Editar(int id)
        //{
        //    var comando = new SqlCommand();
        //    comando.Connection = Conexao.connection;
        //    comando.CommandText = "SEL_DADOS_ANUNCIO @ID";
        //    comando.Parameters.AddWithValue("@ID", Convert.ToInt32(id));
        //    // comando.Parameters.AddWithValue("@id",id);
        //    Conexao.Conectar();

        //    var reader = comando.ExecuteReader();
        //    var Dados = new List<Retorno_Lista>();
        //        foreach (var item in Dados)
        //        {
        //            ViewBag.ID = item.ID;
        //            ViewBag.Marca = item.Marca;
        //            ViewBag.Modelo = item.Modelo;
        //            ViewBag.Versao = item.Versao;
        //            ViewBag.Ano = item.Ano;
        //            ViewBag.klm = item.klm;
        //            ViewBag.Obs = item.Obs;
        //        };
        //    return View();
        //}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite
{
    public class SiteSupport
    {
        public enum RedirectType
        {
            Banda = 0,
            Usuario = 1,
            InstrumentoMusical = 2,
            EstiloMusical = 3,
            BandaAdministrativo = 4
        }

        //private static System.Web.SessionState.HttpSessionState objSession;
        //public static XaduxClassLibrary.Usuario UsuarioLogado
        //{
        //    get
        //    {
        //        if (objSession == null)
        //            return null;

        //        if (objSession["SiteSupport_UsuarioLogado"] == null)
        //            return null;
        //        return (XaduxClassLibrary.Usuario)objSession["SiteSupport_UsuarioLogado"];
        //    }
        //    set
        //    {
        //        if (objSession == null)
        //            return;

        //        if (value == null)
        //            objSession.Remove("SiteSupport_UsuarioLogado");
        //        else
        //            objSession["SiteSupport_UsuarioLogado"] = value;
        //    }
        //}

        //public static void LogIn(System.Web.SessionState.HttpSessionState tempSession, XaduxClassLibrary.Usuario user)
        //{
        //    objSession = tempSession;
        //    UsuarioLogado = user;
        //}

        public static string CommandRedirect(RedirectType tipo, string value)
        {
            value = value.Replace(' ', '-');
            switch (tipo)
            {
                case RedirectType.Banda:
                    return "~/" + value;
                case RedirectType.Usuario:
                    return "~/usuarios/" + value;
                case RedirectType.InstrumentoMusical:
                    return "~/instrumentos/" + value;
                case RedirectType.EstiloMusical:
                    //return "~/portal/" + value;
                    return "~/busca.aspx?estiloMusical=" + value;
                case RedirectType.BandaAdministrativo:
                    return "~/restrito/" + value + "/banda.aspx";
                default:
                    return string.Empty;
            }
        }
        public static string CommandRedirect(WebControl sender)
        {
            string commandName = string.Empty;
            string commandArgument = string.Empty;

            if (sender is Button)
            {
                commandName = ((Button)sender).CommandName;
                commandArgument = ((Button)sender).CommandArgument;
            }
            if (sender is ImageButton)
            {
                commandName = ((ImageButton)sender).CommandName;
                commandArgument = ((ImageButton)sender).CommandArgument;
            }
            if (sender is LinkButton)
            {
                commandName = ((LinkButton)sender).CommandName;
                commandArgument = ((LinkButton)sender).CommandArgument;
            }

            if (commandName != string.Empty && commandArgument != string.Empty)
            {
                switch (commandName.ToLower())
                {
                    case "estilomusical":
                        return SiteSupport.CommandRedirect(SiteSupport.RedirectType.EstiloMusical, commandArgument);
                    case "instrumentomusical":
                        return SiteSupport.CommandRedirect(SiteSupport.RedirectType.InstrumentoMusical, commandArgument);
                    case "banda":
                        return SiteSupport.CommandRedirect(SiteSupport.RedirectType.Banda, commandArgument);
                    case "usuario":
                        return SiteSupport.CommandRedirect(SiteSupport.RedirectType.Usuario, commandArgument);
                    case "bandaadministrativo":
                        return SiteSupport.CommandRedirect(SiteSupport.RedirectType.BandaAdministrativo, commandArgument);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Salva a imagem de acordo com os parâmetros passados e retorna o caminho no qual o arquivo foi salvo
        /// </summary>
        /// <param name="upd"></param>
        /// <param name="pastaParaSalvar"></param>
        /// <param name="nomeArquivo"></param>
        /// <returns></returns>
        public static string SalvarImagem(System.Web.UI.WebControls.FileUpload upd, string pastaParaSalvar, string nomeImagem)
        {
            //pastaParaSalvar = pastaParaSalvar.Replace(' ', '-');
            //pastaLogica = pastaLogica.Replace(' ', '-');
            nomeImagem = nomeImagem.Replace(' ', '-');

            if (!System.IO.Directory.Exists(pastaParaSalvar))
                System.IO.Directory.CreateDirectory(pastaParaSalvar);

            //Controle de tamanho dos arquivos por tipo
            //Para consulta dos MIME Types: http://www.w3schools.com/media/media_mimeref.asp
         
            switch (upd.PostedFile.ContentType)
            {
                case "image/bmp":
                case "image/jpeg":
                case "image/png":
                case "image/gif":
                case "image/pjpeg":
                    if (upd.PostedFile.ContentLength > 1000000) //Maior que 1mb
                        throw new Exception(string.Format("O limite de tamanho de arquivos do tipo '{0}' é 1MB.", upd.PostedFile.ContentType));

                    #region temp
                    string nomeAux = nomeImagem;
                    //Enquanto encontrar o nome do arquivo for igual a algum já salvo, continua tentando nomes diferentes.
                    //Foi colocado um limite de 100, para que não entre em loop infinito
                    for (int cont = 1; System.IO.File.Exists(pastaParaSalvar + "/" + nomeImagem) && cont < 100; cont++)
                    {
                        nomeAux = cont.ToString() + "-" + nomeImagem;
                    }
                    nomeImagem = nomeAux;

                    //Gera uma imagem menor, caso a imagem enviada seja muito grande
                    int HeightMax = 500;
                    int WidthMax = 500;

                    System.Drawing.Image originalImage = System.Drawing.Image.FromStream(upd.FileContent);

                    int auxHeight = originalImage.Height;
                    int auxWidth = originalImage.Width;

                    if (auxHeight > HeightMax || auxWidth > WidthMax)
                    {
                        if (auxHeight > auxWidth)
                        {
                            auxWidth = HeightMax * auxWidth / auxHeight;
                            auxHeight = HeightMax;
                        }
                        else
                        {
                            auxHeight = WidthMax * auxHeight / auxWidth;
                            auxWidth = WidthMax;
                        }

                        System.Drawing.Image newImage = originalImage.GetThumbnailImage(
                            auxWidth,
                            auxHeight,
                            new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback),
                            IntPtr.Zero);

                        newImage.Save(pastaParaSalvar + "/" + nomeImagem);
                    }
                    else
                    {
                        upd.SaveAs(pastaParaSalvar + "/" + nomeImagem);
                    }
                    #endregion

                    break;
                default:
                    throw new Exception(string.Format("Selecione um arquivo no formato de imagem."));
                    
            }
            return nomeImagem;
        }

        public static string SalvarMusica(System.Web.UI.WebControls.FileUpload upd, string pastaParaSalvar, string nomeArquivo)
        {
            //pastaParaSalvar = pastaParaSalvar.Replace(' ', '-');
            //pastaLogica = pastaLogica.Replace(' ', '-');
            nomeArquivo = nomeArquivo.Replace(' ', '-');

            if (!System.IO.Directory.Exists(pastaParaSalvar))
                System.IO.Directory.CreateDirectory(pastaParaSalvar);

            //Controle de tamanho dos arquivos por tipo
            //Para consulta dos MIME Types: http://www.w3schools.com/media/media_mimeref.asp
            switch (upd.PostedFile.ContentType)
            {
                case "audio/x-wav":
                case "audio/mid":
                case "audio/wav":
                case "audio/mpeg":
                case "audio/mp3":
                    if (upd.PostedFile.ContentLength > 10000000) //Maior que 10mb
                        throw new Exception(string.Format("O limite de tamanho de arquivos do tipo '{0}' é 10MB.", upd.PostedFile.ContentType));
                    upd.SaveAs(pastaParaSalvar + "/" + nomeArquivo);
                    break;
                default:
                    throw new Exception(string.Format("Selecione um arquivo no formato de áudio."));
            }

            return nomeArquivo;
        }

        /// <summary>
        /// Método para criação de Thumbnail
        /// </summary>
        /// <param name="Server">Objeto Server da página</param>
        /// <param name="caminhoFisicoImagemOriginal">Caminho da imagem original. Obs: É necessário estar junto o nome do arquivo</param>
        /// <param name="caminhoFisicoImagemFinal">Caminho da imagem final. Obs: É necessário estar junto o nome do arquivo</param>
        public static void CriarThumbnailImage(HttpServerUtility Server, string caminhoFisicoImagemOriginal, string caminhoFisicoImagemFinal)
        {
            int HeightMax = 50;
            int WidthMax = 50;

            //caminhoFisicoImagemOriginal = caminhoFisicoImagemOriginal.Replace(' ', '-');
            //caminhoFisicoImagemFinal = caminhoFisicoImagemFinal.Replace(' ', '-'); 

            int auxHeight = 0;
            int auxWidth = 0;
            int topSpaceHeight = 0;
            int topSpaceWidth = 0;
            System.Drawing.Image uploaded = System.Drawing.Image.FromFile(caminhoFisicoImagemOriginal);
            System.Drawing.Image clone = System.Drawing.Image.FromFile(Server.MapPath("~/imagens") + "\\imgBanda.jpg").GetThumbnailImage(
                HeightMax,
                WidthMax,
                new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback),
                IntPtr.Zero);

            auxHeight = uploaded.Height;
            auxWidth = uploaded.Width;

            if (auxHeight > auxWidth)
            {
                auxWidth = HeightMax * auxWidth / auxHeight;
                topSpaceWidth = (WidthMax - auxWidth) / 2;
                auxHeight = HeightMax;
            }
            else
            {
                auxHeight = WidthMax * auxHeight / auxWidth;
                topSpaceHeight = (HeightMax - auxHeight) / 2;
                auxWidth = WidthMax;
            }

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(clone);
            graphics.DrawImage(uploaded, topSpaceWidth, topSpaceHeight, auxWidth, auxHeight);
            clone.Save(caminhoFisicoImagemFinal);
        }

        /// <summary>
        /// Exclui o arquivo passado
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <returns></returns>
        public static bool ExcluirArquivo(string caminhoArquivo, HttpServerUtility server)
        {
            try
            {
                //if (System.IO.File.Exists(caminhoArquivo))
                //    System.IO.File.Delete(caminhoArquivo);
                //else
                //{
                caminhoArquivo = caminhoArquivo.Replace(
                    ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"],
                    server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]));
                if (System.IO.File.Exists(caminhoArquivo))
                    System.IO.File.Delete(caminhoArquivo);
                //}

                return true;
            }
            catch { }
            return false;
        }

        public static bool DownloadArquivo(string caminhoArquivo, HttpResponse Response, HttpServerUtility Server)
        {
            try
            {
                caminhoArquivo = caminhoArquivo.Replace(
                        ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"],
                        Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]));
                if (System.IO.File.Exists(caminhoArquivo))
                {
                    System.IO.FileInfo arquivo = new System.IO.FileInfo(caminhoArquivo);
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader(
                        "Content-Disposition",
                        "attachment; filename=\"" + arquivo.Name + "\"");
                    Response.AddHeader(
                        "Content-Length",
                        arquivo.Length.ToString());
                    Response.Flush();
                    Response.WriteFile(arquivo.FullName);

                    return true;
                }
            }
            catch { }
            return false;
        }


        /// <summary>
        /// Método necessário para a criação do Thumbnail
        /// </summary>
        /// <returns></returns>
        private static bool ThumbnailCallback()
        {
            return true;
        }
    }
}
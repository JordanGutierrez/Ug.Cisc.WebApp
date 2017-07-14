using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace SqlDataAccess.Utils
{
    public class Utils
    {
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        //public string EnviarNotificacion(string CodigoPlantilla, string Destino, string Asunto, string DirPlantillas, string CCopia, string CCopiaOculta, string RutaAdjunto, string Etiquetas, ref bool Error, bool EsDirecta, string EtiqG, int AutoMail, string fotos)
        //{
        //    Error = true;
        //    List<string> LstEtiq = Etiquetas.Split(new string[] { "x|x" }, StringSplitOptions.None).ToList();
        //    LstEtiq.RemoveAt(0);
        //    List<string> EtiqGuard = new List<string>();
        //    string archivo = String.Format("{0}{1}.html", DirPlantillas, CodigoPlantilla);
        //    string Result;
        //    string userDef = string.Empty;
        //    if (!EsDirecta)
        //    {
        //        AS_TIPOS_NOTIFICACIONES itnotif = ef.AS_TIPOS_NOTIFICACIONES.Where(x => x.CODIGO == CodigoPlantilla).FirstOrDefault();
        //        if (itnotif == null)
        //        {
        //            Result = "No existe una plantilla con ese código";
        //            return AlertError.Replace("Msg", Result);
        //        }
        //        else
        //        {
        //            EtiqGuard = itnotif.ETIQUETAS.Split('|').ToList();
        //            Asunto = itnotif.NOMBRE_PLANTILLA;
        //            userDef = itnotif.USUARIO_DEFAULT;
        //        }
        //    }
        //    else
        //    {
        //        EtiqGuard = EtiqG.Split('|').ToList();

        //    }


        //    if (EtiqGuard.Count() != LstEtiq.Count())
        //    {

        //        Result = "Las etiquetas enviadas como parámetros no coinciden con las configuradas en la plantilla html";
        //    }
        //    else if (String.IsNullOrWhiteSpace(Destino))
        //    {
        //        Result = "Debe definir al menos un mail de destino";

        //    }

        //    else
        //    {

        //        List<string> dirtoget = Destino.Split(',').ToList();
        //        var invalidas = from a in dirtoget
        //                        where !EsMail(a.Contains('<') ? ((a.Split('<')[1]).Split('>')[0]) : a)
        //                        select a;

        //        if (invalidas.Count() != 0)
        //        {
        //            Result = "Las siguientes direcciones no tienen un formato adecuado: '" + String.Join("|", invalidas.ToArray()) + "'";
        //        }
        //        else
        //        {
        //            AS_TIPO_NOTIF_SMTP itemsmtp = ef.AS_TIPO_NOTIF_SMTP.FirstOrDefault();
        //            if (itemsmtp == null)
        //            {
        //                Result = "No Existe Ningún Servidor Smtp Configurado";
        //            }
        //            else
        //            {
        //                if (String.IsNullOrWhiteSpace(itemsmtp.HOST))
        //                {
        //                    Result = "No Existe Ningún Servidor Smtp Configurado";
        //                }
        //                else
        //                {

        //                    bool EnableSSl = Convert.ToBoolean(itemsmtp.SSL);

        //                    MailMessage VarMsg = new MailMessage();

        //                    string VarUser = itemsmtp.USUARIO;
        //                    VarMsg.From = new MailAddress(itemsmtp.USUARIO, itemsmtp.NOMBRE);
        //                    VarMsg.Subject = Asunto;

        //                    string Mess = String.Empty;

        //                    using (StreamReader sr = new StreamReader(archivo, false))
        //                    {
        //                        Mess = sr.ReadToEnd();
        //                        sr.Close();
        //                    }
        //                    for (int i = 0; i < EtiqGuard.Count(); i++)
        //                    {
        //                        Mess = Mess.Replace("{" + EtiqGuard[i] + "}", LstEtiq[i]);
        //                    }


        //                    if (fotos != null)
        //                    {
        //                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Mess, Encoding.UTF8, MediaTypeNames.Text.Html);
        //                        LinkedResource img = null;
        //                        foreach (string arreglos in fotos.Split('|'))
        //                        {
        //                            string[] prop = arreglos.Split('-');
        //                            try
        //                            {
        //                                img = new LinkedResource(prop[1], MediaTypeNames.Image.Jpeg);
        //                            }
        //                            catch
        //                            {
        //                                img = new LinkedResource(prop[1].Remove(prop[1].Length - 14, 14) + "avatar.jpg", MediaTypeNames.Image.Jpeg);
        //                            }
        //                            img.ContentId = prop[0];
        //                            htmlView.LinkedResources.Add(img);
        //                        }

        //                        VarMsg.AlternateViews.Add(htmlView);

        //                    }
        //                    else
        //                    { // Detecta las imagenes y la agrega en el correo
        //                        string directorio = string.Empty;

        //                        List<string> imagen = IntegrarImagenes(ref Mess);
        //                        if (imagen.Any())
        //                        {
        //                            AlternateView htmlViews = AlternateView.CreateAlternateViewFromString(Mess, Encoding.UTF8, MediaTypeNames.Text.Html);
        //                            LinkedResource imge = null;
        //                            int cont = 0;
        //                            directorio = DirPlantillas.Replace(@"\", @"/");
        //                            directorio = directorio.Substring(0, directorio.IndexOf(imagen[0].Substring(0, 7)));
        //                            foreach (var img in imagen)
        //                            {

        //                                imge = new LinkedResource(directorio + img, MediaTypeNames.Image.Jpeg);
        //                                imge.ContentId = "imagen" + cont;
        //                                htmlViews.LinkedResources.Add(imge);
        //                                cont++;
        //                            }

        //                            VarMsg.AlternateViews.Add(htmlViews);
        //                        }

        //                        else
        //                        {
        //                            VarMsg.Body = Mess;
        //                            VarMsg.IsBodyHtml = true;
        //                        }

        //                    }
        //                    SmtpClient VarClient = new SmtpClient();
        //                    if (!String.IsNullOrEmpty(VarUser))
        //                    {
        //                        VarClient.EnableSsl = EnableSSl;
        //                        VarClient.Credentials = new System.Net.NetworkCredential(VarUser, itemsmtp.PASSWORD);
        //                    }
        //                    VarClient.Port = Convert.ToInt32(itemsmtp.PUERTO);
        //                    VarClient.Host = itemsmtp.HOST;



        //                    if (!String.IsNullOrWhiteSpace(CCopia))
        //                    {
        //                        dirtoget = CCopia.Split(',').ToList();
        //                        invalidas = from a in dirtoget
        //                                    where !EsMail(a.Contains('<') ? ((a.Split('<')[1]).Split('>')[0]) : a)
        //                                    select a;

        //                        if (invalidas.Count() != 0)
        //                        {
        //                            Result = "Las siguientes direcciones no tienen un formato adecuado: '" + String.Join("|", invalidas.ToArray()) + "'";
        //                            return AlertError.Replace("Msg", Result);

        //                        }
        //                        VarMsg.CC.Add(CCopia);
        //                    }

        //                    if (!String.IsNullOrWhiteSpace(userDef))
        //                    {
        //                        VarMsg.CC.Add(userDef);
        //                    }

        //                    if (!String.IsNullOrWhiteSpace(CCopiaOculta))
        //                    {
        //                        dirtoget = CCopiaOculta.Split(',').ToList();
        //                        invalidas = from a in dirtoget
        //                                    where !EsMail(a.Contains('<') ? ((a.Split('<')[1]).Split('>')[0]) : a)
        //                                    select a;

        //                        if (invalidas.Count() != 0)
        //                        {
        //                            Result = "Las siguientes direcciones no tienen un formato adecuado: '" + String.Join("|", invalidas.ToArray()) + "'";
        //                            return AlertError.Replace("Msg", Result);

        //                        }
        //                        VarMsg.CC.Add(CCopiaOculta);
        //                    }
        //                    VarMsg.To.Add(Destino);
        //                    ServicePointManager.ServerCertificateValidationCallback =
        //        delegate (object s, X509Certificate certificate,
        //        X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //        { return true; };


        //                    if (!String.IsNullOrWhiteSpace(RutaAdjunto))
        //                    {
        //                        Attachment Data = new Attachment(RutaAdjunto);
        //                        ContentDisposition VarDisposition = Data.ContentDisposition;
        //                        VarDisposition.CreationDate = System.IO.File.GetCreationTime(RutaAdjunto);
        //                        VarDisposition.ModificationDate = System.IO.File.GetLastWriteTime(RutaAdjunto);
        //                        VarDisposition.ReadDate = System.IO.File.GetLastAccessTime(RutaAdjunto);
        //                        VarMsg.Attachments.Add(Data);
        //                        VarClient.Send(VarMsg);
        //                        Data.Dispose();
        //                    }
        //                    try
        //                    {
        //                        VarClient.Send(VarMsg);
        //                        Error = false;
        //                        Result = "Notificación enviada exitosamente";
        //                    }
        //                    catch
        //                    {
        //                        Error = true;
        //                        Result = "Error al conectarse con el servidor de correo";
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (EsDirecta)
        //    {
        //        if (Error)
        //            Result = AlertError.Replace("Msg", Result);
        //        else
        //        {
        //            Result = AlertExito.Replace("Msg", Result);
        //            if (AutoMail == 1)
        //                Result = "ok";
        //        }


        //    }
        //    return Result;
        //}
    }
}

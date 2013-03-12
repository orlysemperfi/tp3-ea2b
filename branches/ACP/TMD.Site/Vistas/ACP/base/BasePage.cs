using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.IO.Compression;
using System.Globalization;

namespace TMD.ACP.Site
{
    public class BasePage : BasicPage, System.Web.UI.ICallbackEventHandler
    {       

        private System.Collections.Generic.List<string> m_resultCallback = new System.Collections.Generic.List<string>();

        public void AddCallbackValue(string Value)
        {
            if (IsCallback)
            {
                m_resultCallback.Add(Value);
            }
        }

       
        public void AddCallbackControl(System.Web.UI.Control Control)
        {
            if (IsCallback)
            {
                m_resultCallback.Add(GetHtmlControl(Control));
            }
        }
        

        public void RemoveCallBackValueAt(int index)
        {
            m_resultCallback.RemoveAt(index);
        }

        public void ClearCallBackValues()
        {
            m_resultCallback.Clear();
        }

        private void Page_Init(object sender, System.EventArgs e)
        {
            string mScript = ClientScript.GetCallbackEventReference("", "", "", "", "", false);
            if (this.Page.IsCallback)
            {

                if (string.IsNullOrEmpty(Request["__FORMCALLBACK"]))
                {
                    try
                    {
                        this.Controls.Clear();

                    }
                    catch
                    {
                    }
                }
            }
        }

        public string GetCallbackResult()
        {
            //Enviar los resultados del callback en un cadena
            string mReturnValue = null;
            //mReturnValue = Strings.Join(m_resultCallback.ToArray(), ":::");
            mReturnValue = String.Join(":::", m_resultCallback);
            return mReturnValue;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string[] mArguments = eventArgument.Split('|');
            MethodInfo mMethodInfo = null;
            string[] mParameters = null;

            if (mArguments.Length > 1)
            {
                if (string.IsNullOrEmpty(mArguments[1]))
                {
                    mParameters = null;
                }
                else
                {
                    mParameters = mArguments[1].Split(':');

                    for (int i = 0; i <= mParameters.Length - 1; i++)
                    {
                        mParameters[i] = System.Web.HttpUtility.UrlDecode(mParameters[i]);
                    }
                }

            }
            else
            {
                mParameters = null;
            }

            mMethodInfo = this.GetType().GetMethod(mArguments[0]);
            try
            {
                mMethodInfo.Invoke(this, mParameters);
            }
            catch (Exception ex)
            {
                if (Request.Url.ToString().ToLower().IndexOf("/errorpage.aspx") == -1)
                {
                    /*System.Net.WebException WE = new System.Net.WebException();
                    WE.CurrentException = ex;
                    WE.FloodCount = 10;
                    WE.FloodMins = 5;
                    WE.Handle();*/
                }
            }
        }


        public BasePage()
        {
            Init += Page_Init;
        }

        public static string GetHtmlControl(System.Web.UI.Control Control)
        {
            string mResultValue = null;

            StringWriter mStringWriter = new StringWriter();
            System.Web.UI.HtmlTextWriter mHtmlWriter = new System.Web.UI.HtmlTextWriter(mStringWriter);

            Control.RenderControl(mHtmlWriter);

            mHtmlWriter.Flush();
            mResultValue = mStringWriter.ToString();

            mHtmlWriter.Close();
            mStringWriter.Close();

            mHtmlWriter.Dispose();
            mStringWriter.Dispose();

            return mResultValue;
        }


    }
}
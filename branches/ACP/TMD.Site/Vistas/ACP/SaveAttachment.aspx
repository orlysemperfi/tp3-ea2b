<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveAttachment.aspx.cs" Inherits="TMD.CF.Site.Vistas.ACP.SaveAttachment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
     //***************************************************************************** 
     function window_onload(){     
     <%=GetResponse() %>
        try{
          if (!(document.getElementById("__FromSave").value=="")){          
              parent.document.getElementById("MainContent___File").value = document.getElementById("__File").value
              parent.document.getElementById("MainContent___FileName").value = document.getElementById("__FileName").value
              parent.document.getElementById("MainContent___Size").value = document.getElementById("__Size").value
              parent.document.getElementById("MainContent___Message").value = document.getElementById("__Message").value
              parent.document.getElementById("MainContent___Extension").value = document.getElementById("__Extension").value                    
            }

            if (document.getElementById("__FromSave").value=="1"){
		        parent.Replace(2)
                parent.document.getElementById("MainContent_lblFile").innerHTML = document.getElementById("__File").value
		        parent.fSaveAll()
		    }

            if (document.getElementById("__FromSave").value=="2"){
                    parent.RefreshFileUpload()
            }

        }catch(e){}  
    } 
    //*****************************************************************************  
     function questionUpload2(fControl,fromSave){
          f=document.getElementById(fControl)                
          if (!(f.value=="")){
            try
            { 
		        CheckResponse = /\.(PDF|pdf|DOC|doc|DOCX|docx|XLS|xls|XLSX|xlsx|PPT|ppt|PPTX|pptx)$/i.test(f.value);
		        if (!CheckResponse){			        
		            alert("Formato del archivo no valido.")	
                    if (fromSave==2){		            
		            parent.document.getElementById("trBtnUpload").style.display = ""
		            }	        
		            return;
                }	
                if (fromSave == 1){
                   //wait
                }else{
                    mFrom = fromSave
                }	                       
                document.getElementById("__FromSave").value = fromSave                                 
                document.forms["form1"].submit();
            }catch(e){                
                alert("File doesn't exist. Please check and try again.")        
            }
         }else{
            if (fromSave==2){
              alert("Only *.avi,*.wmv,*mpg extension files are accepted.");              
		      parent.document.getElementById("trBtnUpload").style.display = ""
            }else{
              if (!(parent.document.getElementById("MainContent___FileName").value=="")) {
                parent.Replace(2)
              }
              parent.fSaveAll();
            }
        }
    }
    //*****************************************************************************  
     function questionUpload(fControl,fromSave){
            window.setTimeout("questionUpload2('"+fControl+"','"+fromSave+"')",200)
    }

    //*****************************************************************************  
     </script>
   
</head>
<body onload="window_onload();">
     <form id="form1" action="SaveAttachment.aspx" enctype="multipart/form-data" runat="server">
     <asp:TextBox ID="__FileName" style="display:none" runat="server"></asp:TextBox>
     <asp:TextBox ID="__File" style="display:none" runat="server"></asp:TextBox>
     <asp:TextBox ID="__Size" style="display:none" runat="server"></asp:TextBox>
     <asp:TextBox ID="__FromSave" style="display:none" Text="0" runat="server"></asp:TextBox>
     <asp:TextBox ID="__Extension" style="display:none" runat="server"></asp:TextBox>
     <asp:TextBox ID="__Message" style="display:none"  runat="server"></asp:TextBox>     
    <div>
        <input id="FileUpload" type="file" runat="server" size="37" />
    </div>
    </form>
</body>
</html>

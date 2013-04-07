
function insertAtCursor(myField, myValue) {
  //IE support
  if (document.selection) {
    myField.focus();
    sel = document.selection.createRange();
    sel.text = myValue;
  }
  //MOZILLA/NETSCAPE support
  else if (myField.selectionStart || myField.selectionStart == "0") {
    var startPos = myField.selectionStart;
    var endPos = myField.selectionEnd;
    myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);
  } else {
    myField.value += myValue;
  }
}
//**************************************************
function setupHtmlCombo(elementName, html){
    document.getElementById(elementName).name = "__"
            
    document.getElementById(elementName).parentNode.innerHTML = html

}
//**************************************************
function detectBrowser(){
    var mReturnValue = null
    var mAgent = new String(navigator.userAgent.toLowerCase())

    if (mAgent.indexOf("msie") !== -1){
        mReturnValue = "IE"
    }else if(mAgent.indexOf("firefox") !== -1){
        mReturnValue = "FF"
    }else if(mAgent.indexOf("chrome") !== -1){
        mReturnValue = "CHR"
    }else if(mAgent.indexOf("safari") !== -1){
        mReturnValue = "SF"
    }else if(mAgent.indexOf("opera") !== -1){
        mReturnValue = "OP"
    }
        
    return mReturnValue

}

//**************************************************
function stopEvent(event){
    if (event == null){
        return
    }
    
    var mBrowser = detectBrowser()
    
    switch (mBrowser){
        case "IE":
            event.returnValue = false
            break;
        case "FF":
            event.preventDefault()
            break;
        case "SF":
            event.preventDefault()
            event.stopPropagation()
            break;
        case "OP":
            event.preventDefault()
            break;            
    }
}
//**************************************************
function OpenPopup(url, title, width, height, a, fid, f){
  window.setTimeout(function(){
    jQuery.facebox('<div style="width:'+width+'px; height:'+height+'px"><iframe src="'+url+'" frameborder="0" width="100%" height="100%" id="facebox-iframe" class="frame-container"></iframe></div>',false,"simpleFacebox",false)
  }, 100)
  

  if (fid!=null && f !=null){
    arrRefFunctions[fid] = f;
  }
}
function OpenMultiPopup(url, title, width, height, a, fid, f,key,titleclass,isedit,showSaveNewButton,showSaveButton,showCancelButton,showPrintButton,showAddItemButton,isCascade){

if ((showSaveNewButton==undefined)||(showSaveNewButton==null)){
  showSaveNewButton = true
}

if ((showSaveButton==undefined)||(showSaveButton==null)){
  showSaveButton = true
}

if ((showCancelButton==undefined)||(showCancelButton==null)){
  showCancelButton = true
}

if ((isCascade==undefined)||(isCascade==null)){
  isCascade = true
}

  window.setTimeout(function(){      
    jQuery.facebox('<div style="width:'+width+'px; height:'+height+'px"><iframe src="'+url+'" frameborder="0" width="100%" height="100%" id="facebox-iframe-'+key+'" class="frame-container"></iframe></div>',
    false,
    key,
    isCascade,title,titleclass,isedit,showSaveNewButton,showSaveButton,showCancelButton,showPrintButton,showAddItemButton)
  }, 100)

  if (fid!=null && f !=null){
    arrRefFunctions[fid] = f;
  }
}
//**************************************************
function ClosePopup(){
  var faceboxWindow = document.getElementById("facebox-iframe").contentWindow
  if (faceboxWindow.WindowClose)
    faceboxWindow.WindowClose()

    $.facebox.close("simpleFacebox")
//  $(document).trigger('close.facebox');  
}
//**************************************************
function CloseMultiPopup(key){
  var faceboxWindow = document.getElementById("facebox-iframe-"+key);
  if(faceboxWindow){
    if(faceboxWindow.contentWindow){
      if (faceboxWindow.WindowClose){
        faceboxWindow.WindowClose();
      }
    } 
  }   
  $.facebox.close(key)
}
//**************************************************
function notSafariPostBack(){
  try{
  if(detectBrowser()=="SF"){
   var f=document.forms[0];
   if(f){
    f.onsubmit=function(){return false;}
   }  
  }
  }catch(e){} 
}
//**************************************************
function notPostBack(){
 try{
  var f=document.forms[0];
  if(f){
   f.onsubmit=function(){return false;}
  }   
 }catch(e){}
}
//**************************************************
function getElementsByNameEx(name){
  var output = null
  var collection = document.getElementsByName(name)
  
  if (collection.length !== 0){
    output = collection
  }else{
    output = new Array()
    output.push(collection)
  
  }
  
  return output 

}
//**************************************************
function remove_options(obj){
	var j = obj.length
	for (i=0; i<j; i++){
		obj.remove(0)
	}
}
//**************************************************************************
function addOption(objNm, valueID, valueText) {
	var idx = window.document.getElementById(objNm).options.length;
  var newOpt = new Option(valueText, valueID);
  
  window.document.getElementById(objNm).options[idx] = newOpt
}
//**************************************************
function ApplyColorPickerMini(ctrlShowPicker, ctrlShowValue){

  $("#" + ctrlShowPicker).ColorPicker({
	  onSubmit: function(hsb, hex, rgb){
		  $("#" + ctrlShowValue).val("#" + hex);		  
		  $("#" + ctrlShowValue).change()
	  },
	  mini: true,
	  onBeforeShow: function () {
  		  $(this).ColorPickerSetColor($("#" + ctrlShowValue).val().replace("#", ""));
	  }
  })
  .bind('keyup', function(){
	  $(this).ColorPickerSetColor($("#" + ctrlShowValue).val().replace("#", ""));
  });

}
//**************************************************
function ApplyColorPicker(ctrlShowPicker, ctrlShowValue){

  $("#" + ctrlShowPicker).ColorPicker({
	  onSubmit: function(hsb, hex, rgb){
		  $("#" + ctrlShowValue).val("#" + hex);		  
		  $("#" + ctrlShowValue).change()
	  },
	  onBeforeShow: function () {
  		  $(this).ColorPickerSetColor($("#" + ctrlShowValue).val().replace("#", ""));
	  }
  })
  .bind('keyup', function(){
	  $(this).ColorPickerSetColor($("#" + ctrlShowValue).val().replace("#", ""));
  });

}
//**************************************************
function Left(str, n){
	if (n <= 0)
	    return "";
	else if (n > String(str).length)
	    return str;
	else
	    return String(str).substring(0,n);
}
//**************************************************************************
function Right(str, n){
    if (n <= 0)
       return "";
    else if (n > String(str).length)
       return str;
    else {
       var iLen = String(str).length;
       return String(str).substring(iLen, iLen - n);
    }
}
//*****************************************************************************
function getCheckboxValue(elementName){
  var elementValue = 0
  
  var collection = document.getElementsByName("rdLandingPages")
  
  for (i=0;i<collection.length;i++){
    if (collection[i].checked){
      return collection[i].value      
    }    
  }
}

function compare_dates(fecha, fecha2) {
    var xMonth = fecha.substring(3, 5);
    var xDay = fecha.substring(0, 2);
    var xYear = fecha.substring(6, 10);
    var yMonth = fecha2.substring(3, 5);
    var yDay = fecha2.substring(0, 2);
    var yYear = fecha2.substring(6, 10);
    if (xYear > yYear) {
        return (true)
    }
    else {
        if (xYear == yYear) {
            if (xMonth > yMonth) {
                return (true)
            }
            else {
                if (xMonth == yMonth) {
                    if (xDay > yDay)
                        return (true);
                    else
                        return (false);
                }
                else
                    return (false);
            }
        }
        else
            return (false);
    }
}  

function isDate(txtDate)
{
    var currVal = txtDate;
    if(currVal == '')
    return false;
    //Declare Regex 
    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern); // is format OK?
    if (dtArray == null)
        return false;
    //Checks for dd/mm/yyyy format.
    dtMonth = dtArray[3];
    dtDay= dtArray[1];
    dtYear = dtArray[5];
    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay> 31)
        return false;
    else if ((dtMonth==4 || dtMonth==6 || dtMonth==9 || dtMonth==11) && dtDay ==31)
        return false
    else if (dtMonth == 2)
    {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay> 29 || (dtDay ==29 && !isleap))
            return false;
    }
    return true;
}

function CalculateDateDiff(inicio, fin)
{
    var d1 = inicio.split("/");
	var dat1 = new Date(d1[2], parseFloat(d1[1])-1, parseFloat(d1[0]));
	var d2 = fin.split("/");
	var dat2 = new Date(d2[2], parseFloat(d2[1])-1, parseFloat(d2[0]));
	var difference = (dat2 - dat1);
	var years = Math.floor(difference / (1000 * 60 * 60 * 24 * 365));
	difference -= years * (1000 * 60 * 60 * 24 * 365);
	var months = Math.floor(difference / (1000 * 60 * 60 * 24 * 30.4375));
	var dif = '';
	if (years > 0)
	    dif = years*12;
	if (months > 0) {
	    dif += months;
	}
	return dif;
}
//**************************************************************************
function DoCallBack(functionName, functionArguments, endFunction, context){
 var vstateID = document.getElementById("__VIEWSTATEID");
 var vstateData;
 if(vstateID != null){
     vstateID = vstateID.value;   
 }
 if(vstateID != null && vstateID.length > 0){
   vstateData = document.getElementById(vstateID);
 }
 if(vstateData != null){
   vstateData = vstateData.value;
 }
 if(vstateData == null){
   vstateData = "";
 }
 __theFormPostData = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=&"  + vstateID + "=" + vstateData + "&";   
 WebForm_DoCallback('__Page', functionName + '|' + functionArguments, endFunction, context, callback_Error, false)        
}
//**************************************************************************
function callback_Error(message, context){
alert(message)
}
//**************************************************************************
function setupHtmlCombo(elementName, html){
 document.getElementById(elementName).name = "__"
 document.getElementById(elementName).parentNode.innerHTML = html
}
//**************************************************************************
function DoFormCallBack(functionName, dummy, endFunction) {   
    mFormData = new String()
    InitFormCallback()  
    __theFormPostData = "__FORMCALLBACK=1&__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=&" + mFormData    
    WebForm_DoCallback('__Page', functionName, endFunction, null, callback_Error, false)    
}
//**************************************************************************
function InitFormCallback() {
 var count = theForm.elements.length;
 var element;
 for (var i = 0; i < count; i++) {
   element = theForm.elements[i];
   var tagName = element.tagName.toLowerCase();
   if (tagName == "input") {
    var type = element.type;
    if ((type == "text" || type == "hidden" || type == "password" || ((type == "checkbox" || type == "radio") && element.checked)) && (element.id != "__EVENTVALIDATION" && element.id != "__VIEWSTATE" && element.id != "__EVENTTARGET" && element.id != "__EVENTARGUMENT")) {
     InitCallbackAddField(element.name, element.value);
    }
   }
   else if (tagName == "select") {
    var selectCount = element.options.length;
    for (var j = 0; j < selectCount; j++) {
     var selectChild = element.options[j];
     if (selectChild.selected == true) {
      InitCallbackAddField(element.name, element.value);
     }
    }
   }
   else if (tagName == "textarea") {
    InitCallbackAddField(element.name, element.value);
   }
}
}

//**************************************************************************
function InitCallbackAddField(name, value) {
  mFormData += name + "=" + WebForm_EncodeCallback(value) + "&";
}

//**************************************************************************
/*function addOption(objNm, valueID, valueText) {
	var idx = window.document.getElementById(objNm).options.length;
  var newOpt = new Option(valueText, valueID);
  window.document.getElementById(objNm).options[idx] = newOpt
}*/
//**************************************************************************
/*function remove_options(obj){
var j = obj.length
for (i=0; i<j; i++){
obj.remove(0)
}
}*/
//**************************************************************************
/*function remove_options_blank(Obj){
remove_options(document.all(Obj));
addOption(Obj,0,"");
}*/
//**************************************************************************
/*function stopEvent(event){
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
event.stopPropagation()
break;
case "OP":
event.preventDefault()
break;            
}
}*/
//**************************************************************************
/*function detectBrowser(){
var mReturnValue = null
var mAgent = new String(navigator.userAgent.toLowerCase())
if (mAgent.indexOf("msie") !== -1){
mReturnValue = "IE"
}else if(mAgent.indexOf("firefox") !== -1){
mReturnValue = "FF"
}else if(mAgent.indexOf("safari") !== -1){
mReturnValue = "SF"
}else if(mAgent.indexOf("opera") !== -1){
mReturnValue = "OP"
}
return mReturnValue
}*/
//**************************************************************************
/*function addEvent(object, evt, func, capture){
if(typeof func != 'function'){
return false;
}
if(object.addEventListener){
object.addEventListener(evt, func, capture);
return true;
}
else if(object.attachEvent){
object.attachEvent('on' + evt, func);
return true;
}
return false;
}*/
//**************************************************************************
/*function add_Event(id, type, handler) {
if (!document.getElementById(id)) {
return false;
} else {
var el = document.getElementById(id);
if (el.addEventListener) {
el.addEventListener(type, handler, false);
} else if (el.attachEvent) {
el.attachEvent("on" + type, handler);
} else {
el.onclick = handler;
}
}
}*/
//**************************************************************************
/*function AttachEvent(obj, eventName, eventHandler) {
if(obj) {
if(eventName.substring(0, 2) == "on") {
eventName = eventName.substring(2,eventName.length);
}
if (obj.addEventListener){
obj.addEventListener(eventName, eventHandler, false);
} else if (obj.attachEvent){
obj.attachEvent("on"+eventName, eventHandler);
}
}
}

*/
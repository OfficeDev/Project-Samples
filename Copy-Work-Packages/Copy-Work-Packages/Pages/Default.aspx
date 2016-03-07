<%-- The following 4 lines are ASP.NET directives needed when using SharePoint components --%>
<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%-- The markup and script in the following Content element will be placed in the <head> of the page --%>
<asp:content contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
   <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js"></script>
   <SharePoint:ScriptLink name="sp.js" runat="server" OnDemand="false" LoadAfterUI="true" Localizable="false" />

   <SharePoint:ScriptLink name="PS.js" runat="server" OnDemand="false" LoadAfterUI="true" Localizable="false" />
   <meta name="WebPartPageExpansion" content="full" />
   <!-- Add your CSS styles to the following file -->
   <link rel="Stylesheet" type="text/css" href="../Content/App.css" />
   <!-- Add your JavaScript to the following file -->
   <script type="text/javascript" src="../Scripts/App.js"></script>
</asp:content>

<%-- The markup in the following Content element will be placed in the TitleArea of the page --%>
<asp:content contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
   Copy Tasks
</asp:content>

<%-- The markup and script in the following Content element will be placed in the <body> of the page --%>
<asp:content contentplaceholderid="PlaceHolderMain" runat="server">
   
   <div>
      <p id="message">
         Hello
      </p>
      <div class="boxer">
         <div class="box-row">
            <div class="box">Project: </div>
            <div class="box">
               <select id="sourceProject">
                  <option value="" >Loading...</option>
               </select>
            </div>
         </div>
         <div class="box-row">
            <div class="box">Summary Task:</div>
            <div class="box">
               <select id="sourceTask">
                  <option value="" ></option>
               </select>
            </div>
         </div>
         <div class="box-row">
            <div class="box"></div>
            <div class="box"></div>
         </div>
         <div class="box-row">
            <div class="box">Project: </div>
            <div class="box">
               <select id="targetProject">
                  <option value="" >Loading...</option>
               </select>
            </div>
         </div>
         <div class="box-row">
            <div class="box">Summary Task: </div>
            <div class="box">
               <select id="targetTask">
                  <option value="" ></option>
               </select>
            </div>
         </div>
      </div>
      <!-- <button id="idButton" type="button" onclick = "handleClick()")> -->
      <input type="button" value="Submit" id="btnSubmit"/>
      <div>
         <p id="checkedOut" style="display:none">
            Target Project is checked out.
         </p>
      </div>
   </div>
</asp:content>
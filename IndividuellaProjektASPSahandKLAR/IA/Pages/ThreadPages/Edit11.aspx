<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit11.aspx.cs" Inherits="Individuella.Pages.ThreadPages.Edit11" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:FormView ID="FormView1" runat="server"
        ItemType="Individuella.Model.Thread"
        DataKeyNames="ThreadID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        UpdateMethod="FormView1_UpdateItem"
        SelectMethod="FormView1_GetItem">
      
             <EditItemTemplate>
          <div>
            <asp:TextBox ID="Titel" runat="server" Text='<%# BindItem.Titel %>' MaxLength="30" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="En Titel måste anges." ControlToValidate="Titel" Display="None" ValidationGroup="ValidationGr"></asp:RequiredFieldValidator>
          
                 </div>
                  <div>
            <asp:TextBox ID="Innehåll" runat="server" Text='<%# BindItem.Innehåll %>' height="200" TextMode="MultiLine" CssClass="innehåll" MaxLength="8000" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Innehåll måste anges." ControlToValidate="Innehåll" Display="None" ValidationGroup="ValidationGr"></asp:RequiredFieldValidator>
          </div>



          <asp:CheckBoxList ID="CheckBoxListTheard" runat="server" 
              SelectMethod="CheckBoxListTheard_GetTags" 
              TextAlign="Left" 
              OnDataBound="CheckBoxListTheard_DataBound"
              DataValueField="TagID" 
              DataTextField="Tag">
          </asp:CheckBoxList>

            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" Text="Spara" CssClass="Detailsbuttons" ValidationGroup="ValidationGr" />
             <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("ThreadDetails", new { id = Item.ThreadID }) %>' CssClass="Detailsbuttons" />
        
    
</EditItemTemplate>
         </asp:FormView>


</asp:Content>




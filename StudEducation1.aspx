<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudEducation1.aspx.cs" Inherits="student.StudEducation1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
    <div class="row">
        <div class="col-md-6 mx-auto">
            <div class="card">
                <div class="card-body">
                   <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                 </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>Education Update</h4>
                        </center>
                     </div>
                 </div>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                 </div>

               <div class="row">
                 <div class="col-md-6">
                     <asp:Panel ID="PanelEducation" runat="server">
                         <label>Education</label><br />
                         <asp:DropDownList ID="DropDownListEducation" runat="server" CssClass="form-control" AutoPostBack="True" >
                             <asp:ListItem Value="">Please Select</asp:ListItem>
                             <asp:ListItem>Degree</asp:ListItem>
                             <asp:ListItem>HSC</asp:ListItem>
                             <asp:ListItem>SSC</asp:ListItem>
                          </asp:DropDownList>
                      </asp:Panel>
                 </div>
                  <div class="col-md-6">
                      <asp:Panel ID="PanelStreamHSC" runat="server">
                          <label>Stream HSC</label><br />
                          <asp:DropDownList ID="DropDownListStreamhsc" runat="server" CssClass="form-control"  AutoPostBack="True">
                              <asp:ListItem Value="">Please Select</asp:ListItem>
                              <asp:ListItem>Science</asp:ListItem>
                              <asp:ListItem>Commerce</asp:ListItem>
                              <asp:ListItem>Art</asp:ListItem>
                          </asp:DropDownList>
                      </asp:Panel>
                      <asp:Panel ID="PanelStreamSSC" runat="server">
                          <label>Stream SSC</label><br />
                          <asp:DropDownList ID="DropDownListStreamSSC" runat="server" CssClass="form-control"  AutoPostBack="True">
                              <asp:ListItem Value="">Please Select</asp:ListItem>
                              <asp:ListItem>SSC</asp:ListItem>
                          </asp:DropDownList>
                      </asp:Panel>
                      <asp:Panel ID="PanelStreamDegree" runat="server">
                          <label>Stream Degree</label><br />
                          <asp:DropDownList ID="DropDownListStreamDegree" runat="server" CssClass="form-control"  AutoPostBack="True">
                              <asp:ListItem Value="">Please Select</asp:ListItem>
                              <asp:ListItem>Engineering</asp:ListItem>
                              <asp:ListItem>Com Sci Engineering</asp:ListItem>
                              <asp:ListItem>IT Engineering</asp:ListItem>
                              <asp:ListItem>BSC</asp:ListItem>
                              <asp:ListItem>BSC IT</asp:ListItem>
                              <asp:ListItem>BSC CS</asp:ListItem>
                          </asp:DropDownList>
                      </asp:Panel>
                  </div>
               </div> 

               <br />
                     
               <div class="row">
                  <div class="col-md-6">
                      <label>Percentage/Aggregate</label>
                       <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxPercentage" runat="server" 
                               placeholder="Percentage"></asp:TextBox>
                        </div>
                     </div>
                 </div>
                    
               <br/>
               <asp:Button ID="Btupdate" runat="server" Text="Update" class="btn btn-primary" Width="50%"/>
               <br/>
               <asp:Button ID="Btcancel" runat="server" Text="cancel" class="btn btn-primary" Width="49%"/>

                </div>                          
            </div>
            <br/>
        </div>
    </div>
</div>
</asp:Content>

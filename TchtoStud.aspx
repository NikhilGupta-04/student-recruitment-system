<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TchtoStud.aspx.cs" Inherits="student.TchtoStud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
    <div class="row">
        <div class="col-md-6 mx-auto"">
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
                           <h4>Jobs</h4>
                        </center>
                        </div>
                    </div>
                   <div class="row">
                        <div class="col">
                        <hr>
                        </div>
                    </div>

                   <asp:GridView ID="GridViewJobs" runat="server" AutoGenerateColumns="False" Width="60%" BorderColor="White">
                       <Columns>
                           <asp:BoundField HeaderText="Name"  DataField="name"/>
                       </Columns>
                   </asp:GridView>
                   <br/>
                   <asp:Button ID="ButtonSend" runat="server" Text="Send All" Width="50%"  class="btn btn-primary" OnClick="ButtonSend_Click"/>
               </div>
            </div>
            <br/>
        </div>
    </div>
</div>
</asp:Content>

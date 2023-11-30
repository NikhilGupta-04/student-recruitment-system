<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HRJobApplication.aspx.cs" Inherits="student.HRJobApplication" %>
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
                           <h4>Application</h4>
                        </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                        <hr>
                        </div>
                    </div>

                    <asp:GridView ID="GridViewApplication" runat="server"  AutoGenerateColumns="False" BorderColor="White"  OnRowCommand="GridViewApplication_RowCommand1">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Student Name" />
                            <asp:BoundField DataField="CollegeName" HeaderText="College Name" />  
                               
                        </Columns>
                    </asp:GridView>

                </div>
            </div>             
           <br>
        </div>
    </div>
</div>

</asp:Content>

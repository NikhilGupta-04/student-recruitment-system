<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JobQualification.aspx.cs" Inherits="student.JobQualification" %>
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
                           <h4>Job Qualification</h4>
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
                            <label>Education</label><br>
                            <asp:DropDownList ID="DropDownListEducation" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Please Select</asp:ListItem>
                                <asp:ListItem>Degree</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Is Required." ControlToValidate="DropDownListEducation" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            <label>Level</label><br>
                            <asp:DropDownList ID="DropDownListlevel" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Please Select</asp:ListItem>
                                <asp:ListItem>Above</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Is Required." ControlToValidate="DropDownListlevel" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-6">
                            <label>Percentage/Aggregate</label><br>
                            <asp:DropDownList ID="DropDownListPercentage" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Please Select</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>55</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Is Required." ControlToValidate="DropDownListPercentage" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>  
                    </div>
                        <br/>
                        <asp:Button ID="BtPost" runat="server" Text="Add" Width="50%" class="btn btn-primary" OnClick="BtPost_Click" PostBackUrl="~/JobQualification.aspx" />
                        <asp:Button ID="BtCancel" runat="server" Text="cancel" class="btn btn-primary" Width="49%"/>
                </div>             
            </div>
            <br />
        </div>
    </div>
</div>
</asp:Content>

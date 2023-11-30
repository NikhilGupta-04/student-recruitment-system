<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TchJobs.aspx.cs" Inherits="student.TchJobs" %>
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
                           <h4> Views Jobs</h4>
                        </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                        <hr>
                        </div>
                    </div>

                      <asp:Panel ID="Paneltchjobdisplay" runat="server">
                       <asp:DataList ID="DataListtchjobdisplay" runat="server" width= "100%">
                           <ItemTemplate>
                               <div class="card" id="postcard">
                                   <div class="card-body">
                                       <div>
                                           <asp:Label ID="LabelCompanyName" runat="server" Text="Company Name : "></asp:Label>
                                           <%# Eval("company_name")%>                  
                                       </div>
                                       <div>
                                           <asp:Label ID="lblJobTittle" runat="server" Text="Job Tittle : "></asp:Label>
                                           <%# Eval("Job_Title")%>                                           
                                       </div>
                                       <div>
                                           <asp:Label ID="lblDepartment" runat="server" Text="Department : "></asp:Label>
                                           <%# Eval("Department")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblSkillsRequired" runat="server" Text="Skills Required : "></asp:Label>
                                           <%# Eval("Skills_Required")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblPackage" runat="server" Text="Package : "></asp:Label>
                                           <%# Eval("Package")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblLocation" runat="server" Text="Location : "></asp:Label>
                                           <%# Eval("Location")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblJobDescription" runat="server" Text="Job Description : "></asp:Label>
                                           <%# Eval("Job_Description")%>
                                       </div>
                                       <div class="row"><div class="col"><hr></div></div>
                                       <div>
                                           <asp:Label ID="Label1" runat="server" Text="Education : "></asp:Label>
                                           <%# Eval("education")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="Label2" runat="server" Text="Level : "></asp:Label>
                                           <%# Eval("Level_Edu").ToString() == "1" ? "Above" : "Below"%>
                                       </div>
                                       <div>
                                           <asp:Label ID="Label3" runat="server" Text="Percantage/Aggregate : "></asp:Label>
                                           <%# Eval("percantage_aggregate")%>
                                       </div>
                                   <br />
                                 <asp:Panel ID="PanelSendtoStudents" runat="server">
                                       <asp:Button ID="ButtonSendtoStudents" runat="server" Text="Send to Students" Width="50%"  class="btn btn-primary" onclick="ButtonSendtoStudents_Click" CommandArgument=<%# Eval("Job_ID")%>  />
                                  </asp:Panel>
                                   </div>
                               </div>
                               <br />
                           </ItemTemplate>
                       </asp:DataList>
                   </asp:Panel>   
                </div>
            </div>             
           <br/>
        </div>
    </div>
</div>
</asp:Content>






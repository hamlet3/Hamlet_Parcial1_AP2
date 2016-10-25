<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial1.Default" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
        .auto-style2 {
            height: 37px;
            width: 673px;
        }
        .auto-style3 {
            width: 673px;
        }
        .auto-style4 {
            margin-right: 194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="BuscarIdtxt" runat="server"></asp:TextBox>
                <asp:Button ID="BuscarIdBtn" runat="server" OnClick="BuscarIdBtn_Click" Text="buscar" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Razon"></asp:Label>
                <asp:TextBox ID="Razontxt" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Material"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Precio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cantidad</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td>
                <asp:TextBox ID="Materialtxt" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Preciotxt" runat="server"></asp:TextBox>
                &nbsp;<asp:TextBox ID="Cantidadtxt" runat="server"></asp:TextBox>
                <asp:Button ID="AgregarBtn" runat="server" OnClick="AgregarBtn_Click" Text="Agregar" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="MaterialesGv" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Material" HeaderText="Material" SortExpression="Material" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="NuevoBtn" runat="server" OnClick="NuevoBtn_Click" Text="Nuevo" />
                <asp:Button ID="GuardarBtn" runat="server" OnClick="GuardarBtn_Click" Text="Guardar" />
                <asp:Button ID="EliminarBtn" runat="server" OnClick="EliminarBtn_Click" Text="Eliminar" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="auto-style2">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" CssClass="auto-style4" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="512px">
                    <LocalReport ReportPath="MaterialesReporte.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="Parcial1.DataSet1TableAdapters.ReporteTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="Parcial1.RazonDSetTableAdapters.ReporteRazonTableAdapter"></asp:ObjectDataSource>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_login.Master" CodeBehind="Login.aspx.vb" Inherits="JUDMB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido_formulario" runat="server">
    <div class="login-box">
        <div class="login-logo">
        <a href="../../index2.html"><b>INVI</b>CDMX</a>
        </div>
        <div class="login-box-body">
        <p class="login-box-msg">Inicie sesion plox</p>
        <div class="form-group has-feedback">
        <input type="text" id="no_empleado" name="no_empleado" class="form-control" placeholder="Numero de empleado">
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
        </div>
        <div class="form-group has-feedback">
        <input type="password" id="password" name="password"   class="form-control" placeholder="Contraseña">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
        </div>
        <div class="row">
        <div class="col-xs-8">
            <div class="checkbox icheck">
            <label class="">
                <div class="icheckbox_square-green" aria-checked="false" aria-disabled="false" style="position: relative;">
                    <input type="checkbox" style="position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;">
                    <ins class="iCheck-helper" style="position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;">
                    </ins>
                </div> 
                Recordarme
            </label>

            </div>
        </div>
        <div class="col-xs-4">
            <button type="submit" id="btn_logear" class="btn btn-success btn-block btn-flat">Ingresar</button>
        </div>
        </div>

        <a href="#">¿Olvido la contraseña?</a><br>

        </div>
     </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="Controladores/Login/Ct_login.js"></script>
</asp:Content>
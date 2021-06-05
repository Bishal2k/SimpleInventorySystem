function showError()
{
    window.onload = function () {
        $("#lblError").html('@Html.Raw(ViewBag.Message)');
        $("#MyPopup").modal("show");
    };
}
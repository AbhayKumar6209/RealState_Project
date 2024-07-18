
function BindBlock(ddlSiteId,ddlBlock,SelectedVal)
{
    debugger
    var siteId = $('#' + ddlSiteId).val();
    if (siteId == '') {
        $('#' + ddlSiteId).html("<option value=''>--none--</option>");
        return;
    }
    $.post('/Master/GetDDLData', { Action: 3, P1: siteId }, function (data) {
        if (data != 'False') {
            var data = eval(data);
            bindDDL(ddlBlock,data);
        }
    })
}
function BindPlotNo(ddlSiteId, ddlBlock, ddlplot, SelectedVal) {
    debugger
    var siteId = $('#' + ddlSiteId).val();
    var blockId = $('#' + ddlBlock).val();
    if (siteId == '' || blockId=='') {
        $('#' + ddlplot).html("<option value=''>--none--</option>");
        return;
    }
    $.post('/Master/GetDDLData', { Action: 4, P1: siteId, P2: blockId }, function (data) {
        if (data != 'False') {
            var data = eval(data);
            bindDDL(ddlplot, data);
        }
    })
}
function bindDDL(ddlid,lst)
{
    var Option = "";
    for (var item of lst) {
        Option += "<option value='" + item.Value + "'>" + item.Text + "</option>";
    }
    $('#' + ddlid).html(Option);
}

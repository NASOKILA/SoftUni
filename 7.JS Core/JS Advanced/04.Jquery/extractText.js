
function extractText() {
  
    let allLiItems = $('#items li').toArray();
    
    $('#result')[0].textContent = allLiItems
        .map(e => $(e).text())
        .join(', ');
}




window.downloadPdf = (base64String, fileName) => {
    const linkSource = `data:application/pdf;base64,${base64String}`;
    const downloadLink = document.createElement("a");
    const fileNameWithExtension = `${fileName}.pdf`;

    downloadLink.href = linkSource;
    downloadLink.download = fileNameWithExtension;
    downloadLink.click();

    alert(`File ${fileNameWithExtension} downloaded successfully in your device`);

};



//json
window.BlazorDownloadFile = (fileName, data) => {
    const blob = new Blob([new Uint8Array(data)], { type: 'application/json' });
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

    // Display a success message after download
    alert(`File ${fileName} downloaded successfully in your device`);
};
window.downloadFileFromStream = (fileName, contentStreamReference) => {
    const arrayBuffer = Uint8Array.from(atob(contentStreamReference), c => c.charCodeAt(0));
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
};
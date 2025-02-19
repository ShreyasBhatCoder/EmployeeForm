function testExec(str) {
    document.getElementById('modalErrorMessage').innerText = `Error connecting to the database: ${str}`;
    document.getElementById('errorModal').style.display = 'block';
}
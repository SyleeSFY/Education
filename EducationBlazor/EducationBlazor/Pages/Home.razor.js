export function ChangeColor() {
    var border = document.getElementById("border");
    border.style.borderColor = GetRandomColor();
}

function GetRandomColor(){
    var ArrayColors = ["blue", "black", "yellow", "red", "green", "purple", "orange"];
    return ArrayColors[Math.floor(Math.random() * ArrayColors.length)];
}
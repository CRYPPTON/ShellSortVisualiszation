var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext('2d'); 
var values = setup();
var delay = 10;
var comparisons = 0;
var arrayAccesses = 0
var i = 0;
var j = i+1;

function randNumb(height){
    return Math.floor(Math.random()*height)             
}

function setup(){
    var values = new Array(canvas.width)                // Set Array Size
    for (var i = 0; i < values.length; i++) {
          values[i] = randNumb(canvas.height)           // Add random numb
    }
    return values
}

function swap(values, i, j){
        temp = values[i];
        values[i] = values[j];
        values[j] = temp
        arrayAccesses+=4
}

function draw(){
    ctx.clearRect(0, 0, canvas.width, canvas.height)
    ctx.beginPath();
    ctx.strokeStyle = "white"
   
            if(i < values.length-1){
               for (var j = i+1; j<values.length; j++){ 
                    var a = values[i]
                    var b = values[j]
                    arrayAccesses+=2;
                        if(a > b){
                            swap(values, i, j)
                        }  
                    comparisons++;
                    }
            } 
            else {
                    var end = new Date().getTime();
                    alert("Finished, array is sorted !!!\nTime : "+(end - start)+"ms"+"\n"+"Delay : "+delay+"ms"+"\nArray accesses = "+arrayAccesses+"\n Total comparisons = "+comparisons)
                    clearInterval(loop)
                    location.reload();
            }
            i++

    for (let i = 0; i < values.length; i++) {            
        ctx.moveTo(0+i, canvas.height);
        ctx.lineTo(0+i, canvas.height - values[i]);
    }
    ctx.stroke();
}

console.log()

var start = new Date().getTime();
var loop = setInterval(draw,delay)







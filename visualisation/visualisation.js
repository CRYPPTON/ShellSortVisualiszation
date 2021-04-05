var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext('2d'); 
var values = setup();
var delay = 400;
var comparisons = 0;
var arrayAccesses = 0
var j = i;
var step = values.length
var i = step;

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


function draw(){
    ctx.clearRect(0, 0, canvas.width, canvas.height)
    ctx.beginPath();
    ctx.strokeStyle = "white"
        
if(step>0){
    while(i<values.length){  
        var k = values[i]
            for( j = i; j>=step && k < values[j-step]; j-=step){
                values[j] = values[j - step]
                comparisons+=2
                arrayAccesses+=3
            }
            values[j] = k
            i++
            comparisons+=1
            arrayAccesses+=1
        }
    comparisons+=1
    i = step  
    step = parseInt(step/2)
    
}else{
    var end = new Date().getTime();
    alert("Finished, array is sorted !!!\nTime : "+(end - start)+"ms"+"\n"+"Delay : "+delay+"ms"+"\nArray accesses = "+arrayAccesses+"\n Total comparisons = "+comparisons)
    clearInterval(loop)
    location.reload();
}
    
    for (let i = 0; i < values.length; i++) {            
        ctx.moveTo(0+i, canvas.height);
        ctx.lineTo(0+i, canvas.height - values[i]);
    }
    ctx.stroke();
}

console.log()

var start = new Date().getTime();
var loop = setInterval(draw,delay)







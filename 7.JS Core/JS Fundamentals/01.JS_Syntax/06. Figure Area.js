

function Area(w,h,W,H) {

    let minHeight = 0;
    let maxHeight = 0;
    let minWidth = 0;
    let maxWidth = 0;

    if(h > H)
    {
        minHeight = H;
        maxHeight = h;
    }
    else
    {
        minHeight = h;
        maxHeight = H;
    }

    if(w > W)
    {
        minWidth = W;
        maxWidth = w;
    }
    else
    {
        minWidth = w;
        maxWidth = W;
    }

    let areaOne = (H * W);
    let areaTwo = (h * w);

    let figureArea = (areaTwo + areaOne) - (minHeight * minWidth);

    console.log(figureArea);
}

Area(2,4,5,3);

Area(13,2,5,8);

Area(1,1,2,2);









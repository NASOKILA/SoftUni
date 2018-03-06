
function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric

    let reversed = arr.slice(0).reverse(); // Clone and reverse

    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    
    return equal;
}



console.log(isSymmetric([1,2,2,1]));
console.log(isSymmetric([2, -1, -1]));
console.log(isSymmetric([-1, 2, -1]));
console.log(isSymmetric([1, -2, 1]));

console.log(isSymmetric({}));
console.log(isSymmetric(false));


//ZA DA Q POLZVAE OT VUNHNIQ SVQT TRQBVA DA Q EXPORTIRAME PO SLEDNIQ NACHIN.
module.exports = isSymmetric;
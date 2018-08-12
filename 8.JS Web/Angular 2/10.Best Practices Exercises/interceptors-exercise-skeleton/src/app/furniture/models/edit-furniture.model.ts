export class EditFurnitureModel {
 
    constructor(
        public id : number,
        public make : string,
        public model : string,
        public year : number,
        public description : string,
        public price : number,
        public image : string,
        public material? : string
    ){}
}
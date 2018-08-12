
import { Pipe, PipeTransform } from '@angular/core';

@Pipe ({
    name : 'capitalize'
})

export class Capitalize implements PipeTransform {

    transform(value: any, ...args: any[]) {
        return value[0].toUpperCase() + value.substring(1).toLowerCase();
    }
}



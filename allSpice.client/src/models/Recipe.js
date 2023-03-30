

export class Recipe {
    constructor(data) {
        this.id = data.id
        this.category = data.category
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.img = data.img
        this.instructions = data.instructions
        this.title = data.title
        this.favorited = false
    }
}
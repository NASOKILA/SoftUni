const Product = require('../models/Product');

module.exports = {
	index: (req, res) => {

        Product.find().then(entries => {
            res.render('product/index', {entries:entries})
        })
    	},

	createGet: (req, res) => {
        res.render('product/create');
	},

	createPost: (req, res) => {

        let product = req.body;

        if(product.name === "")
        {
            res.render('product/create', {product:product});
            return;
        }

        Product.create(product).then(product => {
            res.redirect("/");
        })
	},

	editGet: (req, res) => {

        let id = req.params.id;

        Product.findById(id).then(product => {
            res.render('product/edit', product);
        })

	},

	editPost: (req, res) => {

        let id = req.params.id;
        let product = req.body;

        if(product.name === "" )
        {
            Product.findById(id).then(product => {
                res.render('product/edit', product);
            });
            return;
        }

        Product.findByIdAndUpdate(id, product).then(product => {
            res.redirect('/');
        })

    }
};
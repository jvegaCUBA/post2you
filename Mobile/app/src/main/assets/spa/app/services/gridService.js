app.factory('gridService', [function () {

        var gridService = function(parent, node) {
            var options =
                    {
                        srcNode: node, // grid items (class, node)
                        margin: '10px', // margin in pixel, default: 0px
                        width: '370px', // grid item width in pixel, default: 220px
                        max_width: '', // dynamic gird item width if specified, (pixel)
                        resizable: true, // re-layout if window resize
                        transition: 'all 0.5s ease' // support transition for CSS3, default: all 0.5s ease
                    };
            document.querySelector(parent).gridify(options);
        };
        
        return gridService;
        
    }]);



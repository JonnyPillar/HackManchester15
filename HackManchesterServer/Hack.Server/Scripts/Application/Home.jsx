var react = require('react');
var ReactDOM = require('react-dom');

var CheckLink = react.createElement({
    render: function() {
        // This takes any props passed to CheckLink and copies them to <a>

        var temp = [1, 2, 3];

        return(
            <div>
                Hello again
                {
                    temp.map(function(item){
                        return(
                            <b>{item}</b>
                        );
                    })
                }
            </div>
        );
    }
});

module.exports = function(){
        return (ReactDOM.render(
        CheckLink, document.getElementById('example')
    ));
};
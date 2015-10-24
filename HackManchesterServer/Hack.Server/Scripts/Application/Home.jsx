var CheckLink = React.createClass({
    render: function() {
        // This takes any props passed to CheckLink and copies them to <a>
        return(
            <div>
                Hello again
            </div>
        );
    }
});

module.exports = function(){
    return (ReactDOM.render(
        CheckLink, document.getElementById('homePanel')
    ));
};
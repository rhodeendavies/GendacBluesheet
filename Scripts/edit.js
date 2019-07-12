$(() => {


    $('.redFlaggable').each((index, item) => {
        if (!$(item).val()) {
            $(item).addClass('redFlag');
            $(item).after(
                $('<div></div>')
                    .addClass('input-group-append part')
                    .append(
                        $('<span></span>')
                            .addClass('input-group-text redFlag')
                            .append(
                                $('<i></i>')
                                    .addClass('fas fa-flag')))

                    );
        }
            
    });

    

    $('.redFlaggable').focusout((e)=> {
        console.log($(`#${e.target.id}`));
        if ($(`#${e.target.id}`).val()) {
            $(`#${e.target.id}`).removeClass('redFlag');
            $(`#${e.target.id} ~ .part`).remove();
        }
           
    });

   


});
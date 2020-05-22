<template>
    <div>
        <div>
            <ul class="list-unstyled">
                <b-media tag="li">
                    <template v-slot:aside>
                        <img class="img-avatar" src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQc0ZN8pzI6_zoChyOaZ0kBQFUavxa9IYiOyccKo44IJe-7hDPS&usqp=CAU" alt="Avatar">
                    </template>
                    <h5 class="mt-0 mb-1">Hải Yến</h5>
                    <p class="mb-0">
                        Bài giảng hay!
                    </p>
                </b-media>

                <b-media tag="li" class="my-4">
                    <template v-slot:aside>
                        <img class="img-avatar" src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQc0ZN8pzI6_zoChyOaZ0kBQFUavxa9IYiOyccKo44IJe-7hDPS&usqp=CAU" alt="Avatar">
                    </template>

                    <h5 class="mt-0 mb-1">Bảo Trâm</h5>
                    <p class="mb-0">
                        Font chữ hơi lỗi.
                    </p>
                </b-media>

                <b-media tag="li">
                    <template v-slot:aside>
                        <img class="img-avatar" src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQc0ZN8pzI6_zoChyOaZ0kBQFUavxa9IYiOyccKo44IJe-7hDPS&usqp=CAU" alt="Avatar">
                    </template>

                    <h5 class="mt-0 mb-1">Lưu Ngọc</h5>
                    <p class="mb-0">
                        Well done!
                    </p>
                </b-media>
            </ul>
        </div>


        <div>
            <a-form :form="form" @submit="handleSubmit">
                <a-form-item v-bind="formItemLayout">
                    <span slot="label">
                        Họ tên
                    </span>
                    <a-input v-decorator=" [
  'string',
          {
            rules: [{ required: true, message: 'Xin mời nhập tên!', whitespace: true }],
          },
        ]" />
                </a-form-item>
                <a-form-item v-bind="formItemLayout" label="Số điện thoại">
                    <a-input v-decorator=" ['phone',
{
            rules: [
              {
                minlength: 9, message: 'Số điện thoại không hợp lệ!'
              }
            ]
          }]"
                             style="width: 100%">
                        <a-select slot="addonBefore"
                                  v-decorator="['prefix', { initialValue: '84' }]"
                                  style="width: 70px">
                            <a-select-option value="84">
                                +84
                            </a-select-option>

                        </a-select>
                    </a-input>
                </a-form-item>


                <a-form-item v-bind="formItemLayout" label="E-mail">
                    <a-input v-decorator="[
          'email',
          {
            rules: [
              {
                type: 'email',
                message: 'E-mail không hợp lệ!'
              }
            ]
          }
        ]" />
                </a-form-item>
                <a-form-item v-bind="formItemLayout" label="Bình luận">
                    <a-textarea required placeholder="Nhập bình luận của bạn..." :rows="4" />
                </a-form-item>
                <a-form-item v-bind="tailFormItemLayout">
                    <a-button type="primary" html-type="submit" onclick="window.location.href = '_blank';">
                        Đăng bình luận
                    </a-button>
                </a-form-item>
            </a-form>
        </div>
    </div>

</template>

<script>
      export default {
        data() {
            return {
                confirmDirty: false,
                autoCompleteResult: [],
                formItemLayout: {
                    labelCol: {
                        xs: { span: 24 },         
                        sm: { span: 5 },
                    },
                    wrapperCol: {
                        xs: { span: 24 },
                        sm: { span: 16 },
                    },
                },
                tailFormItemLayout: {
                    wrapperCol: {
                        sm: {
                            span: 16,
                            offset: 8,
                        },
                    },
                },
            };
        },
        beforeCreate() {
            this.form = this.$form.createForm(this, { name: 'submit' });
        },
        methods: {
            handleSubmit(e) {
                e.preventDefault();
                this.form.validateFieldsAndScroll((err, values) => {
                    if (!err) {
                        console.log('Received values of form: ', values);
                    }
                });
            },
            handleConfirmBlur(e) {
                const value = e.target.value;
                this.confirmDirty = this.confirmDirty || !!value;
            },
            compareToFirstPassword(rule, value, callback) {
                const form = this.form;
                if (value && value !== form.getFieldValue('password')) {
                    callback('Two passwords that you enter is inconsistent!');
                } else {
                    callback();
                }
            },
            validateToNextPassword(rule, value, callback) {
                const form = this.form;
                if (value && this.confirmDirty) {
                    form.validateFields(['confirm'], { force: true });
                }
                callback();
            }
            },
        
        };
</script>

<style>
    .img-avatar {
        width: 65px;
        height: 65px;
    }
</style> 